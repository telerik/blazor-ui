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
        internal static DataSourceRequestTemplates GenerateTemplates(this DataSourceRequest request, string selectTableName, string countTableName = null,
            string defaultSortColumnName = "Id", ListSortDirection defaultSortDirection = ListSortDirection.Ascending)
        {
            var start = ((request.Page - 1) * request.PageSize) + 1 + request.Skip;
            var finish = start + request.PageSize - 1;

            var builder = new SqlBuilder();
            var templates = new DataSourceRequestTemplates();

            templates.SelectTemplate = builder.AddTemplate($@"SELECT X.* FROM (
                    SELECT a.*, DENSE_RANK() OVER (/**orderby**/) AS RowNumber
                    FROM {selectTableName} a
                    /**where**/
                ) as X
                WHERE RowNumber BETWEEN @start and @finish", new { start, finish });

            templates.CountTemplate = builder.AddTemplate($@"SELECT COUNT(*) FROM {countTableName ?? selectTableName} a /**where**/");

            foreach (var sort in request.Sorts)
            {
                builder.OrderBy(string.Format("a.{0} {1}", sort.Member, sort.SortDirection == ListSortDirection.Ascending ? "ASC" : "DESC"));
            }

            builder.OrderBy(string.Format("a.{0} {1}", defaultSortColumnName, defaultSortDirection == ListSortDirection.Ascending ? "ASC" : "DESC"));

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
                            filterParamsDic[$"Filter{i}Value"] = (int)Enum.Parse(filterDesc.MemberType, filterDesc.Value?.ToString());
                        }
                        else if (filterDesc.MemberType == typeof(DateTime))
                        {
                            filterParamsDic[$"Filter{i}Value"] = ((DateTime)filterDesc.Value).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            filterParamsDic[$"Filter{i}Value"] = filterDesc.Value?.ToString();
                        }

                        i++;
                    }
                    else
                    {
                        filters.Add($"a.{filterDesc.Member} {props.Op}");
                    }
                }


                StringBuilder sb = new StringBuilder();
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

            return templates;
        }

        internal static FilterDescriptorProperties GetProperties(this FilterDescriptor descriptor)
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
