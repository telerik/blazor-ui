using Dapper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.DataSource;
using TelerikBlazorGrid_Dapper.DataAccess.Models;

namespace TelerikBlazorGrid_Dapper.DataAccess.Extensions
{
    internal static class SqlBuilderExtensions
    {
        /// <summary>
        /// Generates SQL templates to run queries based on a request from Telerik components (Grid)
        /// </summary>
        /// <param name="request">The telerik data request</param>
        /// <param name="selectTableName">The name of the table to look up. Can be a view or function also.</param>
        /// <param name="countTableName">Optional - If provided it will derive the count from a different location than that of the data. Useful in the case of table joins.</param>
        /// <param name="selectParameters">Parameters to pass in for the Select query. Used for the parameters of a function if you are looking up a function.</param>
        /// <param name="countParameters">Parameters to pass in for the Count query. Optional, as it will use Select Params instead if this is null, but the option is there to use different params if needed.</param>
        /// <param name="wheres">Optional. A collection of additional where clauses to append to the entire query (will be "anded")</param>
        /// <param name="defaultSortColumnName">The default name of the column to sort by. Defaults to "Id"</param>
        /// <param name="defaultSortDirection">The default sort direction. Defaults to Ascending.</param>
        /// <returns></returns>
        internal static DataSourceRequestTemplates GenerateTemplates(this DataSourceRequest request, string selectTableName, string countTableName = null,
            DynamicParameters selectParameters = null, DynamicParameters countParameters = null, List<SqlBuilderAppendage> wheres = null,
            string defaultSortColumnName = "Id", ListSortDirection defaultSortDirection = ListSortDirection.Ascending)
        {
            // Calculate the start and finish for the select query for pagination
            var start = ((request.Page - 1) * request.PageSize) + 1 + request.Skip;
            var finish = start + request.PageSize - 1;

            var builder = GenerateBuilder(request, defaultSortColumnName, defaultSortDirection);
            var templates = new DataSourceRequestTemplates();

            string selectTable;
            string? countTable;

            // Determines if we are working with a table / view or a function and creates the correct name variable.
            if (selectParameters is not null)
            {
                selectTable = GetFunctionName(selectTableName, selectParameters);
            }
            else
            {
                selectTable = selectTableName;
                selectParameters = new DynamicParameters();
            }

            selectParameters.Add("Start", start);
            selectParameters.Add("Finish", finish);

            // Determines if we are working with a table / view or a function and created the correct name variable.
            // (Can be null if countTableName and countParameters are both null)
            if (countParameters is not null)
            {
                countTable = GetFunctionName(countTableName ?? selectTableName, countParameters);
            }
            else
            {
                countTable = countTableName;
            }

            // The template for the Select query
            templates.SelectTemplate = builder.AddTemplate($@"SELECT X.* FROM (
                    SELECT a.*, DENSE_RANK() OVER (/**orderby**/) AS RowNumber
                    FROM {selectTable} a
                    /**where**/
                ) as X
                WHERE RowNumber BETWEEN @Start and @Finish", selectParameters);

            // The template for the Count query
            templates.CountTemplate = builder.AddTemplate($@"SELECT COUNT(*) FROM {countTable ?? selectTable} a /**where**/", countParameters ?? selectParameters);

            // If any where's were included, then add them to the builder
            if (wheres is not null)
            {
                foreach (var clause in wheres)
                {
                    builder.Where(clause.Sql, clause.Parameters);
                }
            }

            return templates;
        }

        /// <summary>
        /// Reusable logic which will generate the builder for every request to GenerateTemplates
        /// </summary>
        /// <param name="request">The Telerik data request</param>
        /// <param name="defaultSortColumnName">The default sort column name</param>
        /// <param name="defaultSortDirection">The default sort direction</param>
        /// <returns></returns>
        private static SqlBuilder GenerateBuilder(DataSourceRequest request, string defaultSortColumnName, ListSortDirection defaultSortDirection)
        {
            var builder = new SqlBuilder();

            // Apply each sort according to the data request
            foreach (var sort in request.Sorts)
            {
                builder.OrderBy(string.Format("a.{0} {1}", sort.Member, sort.SortDirection == ListSortDirection.Ascending ? "ASC" : "DESC"));
            }

            // Apply the default sort
            builder.OrderBy(string.Format("a.{0} {1}", defaultSortColumnName, defaultSortDirection == ListSortDirection.Ascending ? "ASC" : "DESC"));

            // Build up and apply each filter
            var i = 0;
            foreach (var filter in request.Filters.Cast<CompositeFilterDescriptor>())
            {
                var filters = new List<string>();
                var filterParams = new ExpandoObject();
                var filterParamsDic = filterParams as IDictionary<string, object>;

                foreach (var filterDesc in filter.FilterDescriptors.Cast<FilterDescriptor>())
                {
                    var props = filterDesc.GetProperties();

                    if (props.HasValue)
                    {
                        filters.Add($"a.{filterDesc.Member} {props.Op} {props.ValuePrefix} @Filter{i}Value {props.ValueSuffix}");

                        if (filterDesc.MemberType.IsEnum)
                        {
                            filterParamsDic[$"Filter{i}Value"] = (int)Enum.Parse(filterDesc.MemberType, filterDesc.Value?.ToString() ?? "");
                        }
                        else if (filterDesc.MemberType == typeof(DateTime))
                        {
                            filterParamsDic[$"Filter{i}Value"] = ((DateTime)(filterDesc?.Value ?? 0)).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            filterParamsDic[$"Filter{i}Value"] = filterDesc.Value?.ToString() ?? "";
                        }

                        i++;
                    }
                    else
                    {
                        filters.Add($"a.{filterDesc.Member} {props.Op}");
                    }
                }

                StringBuilder sb = new();
                sb.Append('(');

                for (int j = 0; j < filters.Count; j++)
                {
                    if (j > 0)
                    {
                        switch (filter.LogicalOperator)
                        {
                            case FilterCompositionLogicalOperator.And:
                                sb.Append(" AND ");
                                break;
                            case FilterCompositionLogicalOperator.Or:
                                sb.Append(" OR ");
                                break;
                            default:
                                break;
                        }
                    }
                    sb.Append(filters[j]);
                }

                sb.Append(')');

                builder.Where(sb.ToString(), filterParams);
            }

            return builder;
        }

        /// <summary>
        /// Generates a parameterised function name. Takes "sfFunctionName" and returns "sfFunctionName(@Param1, @Param2)" if there are 2 params for example.
        /// </summary>
        /// <param name="name">The function name</param>
        /// <param name="parameters">The parameters being passed into the function</param>
        /// <returns></returns>
        private static string GetFunctionName(string name, DynamicParameters parameters)
        {
            var sb = new StringBuilder();

            sb.Append(name);

            sb.Append('(');

            var i = 0;
            foreach (var parameter in parameters.ParameterNames.ToArray())
            {
                if (i > 0)
                {
                    sb.Append(", ");
                }
                sb.Append($"@{parameter}");
                var value = parameters.Get<dynamic>(parameter);
                i++;
            }

            sb.Append(')');

            return sb.ToString();
        }

        // returns the details on how to structure a where clause for a filter descriptor
        private static FilterDescriptorProperties GetProperties(this FilterDescriptor descriptor)
        {
            var properties = new FilterDescriptorProperties();

            switch (descriptor.Operator)
            {
                case FilterOperator.IsLessThan:
                    properties.Op = "<";
                    break;
                case FilterOperator.IsLessThanOrEqualTo:
                    properties.Op = "<=";
                    break;
                case FilterOperator.IsEqualTo:
                    properties.Op = "=";
                    break;
                case FilterOperator.IsNotEqualTo:
                    properties.Op = "!=";
                    break;
                case FilterOperator.IsGreaterThanOrEqualTo:
                    properties.Op = ">=";
                    break;
                case FilterOperator.IsGreaterThan:
                    properties.Op = ">";
                    break;
                case FilterOperator.StartsWith:
                    properties.Op = "LIKE";
                    properties.ValueSuffix = " + '%'";
                    break;
                case FilterOperator.EndsWith:
                    properties.Op = "LIKE";
                    properties.ValuePrefix = "'%' + ";
                    break;
                case FilterOperator.Contains:
                    properties.Op = "LIKE";
                    properties.ValuePrefix = "'%' + ";
                    properties.ValueSuffix = " + '%'";
                    break;
                case FilterOperator.IsContainedIn:
                    properties.Op = "LIKE";
                    properties.ValuePrefix = "'%' + ";
                    properties.ValueSuffix = " + '%'";
                    break;
                case FilterOperator.DoesNotContain:
                    properties.Op = "NOT LIKE";
                    properties.ValuePrefix = "'%' + ";
                    properties.ValueSuffix = " + '%'";
                    break;
                case FilterOperator.IsNull:
                    properties.Op = "IS NULL";
                    properties.HasValue = false;
                    break;
                case FilterOperator.IsNotNull:
                    properties.Op = "IS NOT NULL";
                    properties.HasValue = false;
                    break;
                case FilterOperator.IsEmpty:
                    properties.Op = "= ''";
                    properties.HasValue = false;
                    break;
                case FilterOperator.IsNotEmpty:
                    properties.Op = "!= ''";
                    properties.HasValue = false;
                    break;
                case FilterOperator.IsNullOrEmpty:
                    properties.Op = $"IS NULL OR a.{descriptor.Member} = ''";
                    properties.HasValue = false;
                    break;
                case FilterOperator.IsNotNullOrEmpty:
                    properties.Op = $"IS NOT NULL AND a.{descriptor.Member} != ''";
                    properties.HasValue = false;
                    break;
                default:
                    throw new Exception("Unhandled Operator");
            }

            return properties;
        }
    }
}
