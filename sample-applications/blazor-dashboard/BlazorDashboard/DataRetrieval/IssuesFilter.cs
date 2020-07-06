using BlazorDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDashboard.DataRetrieval
{
	public static class IssuesFilter
	{
		public static DateTime GetRangeFromNumber(int range)
		{
			switch (range)
			{
				case 1: return DateTime.Now.AddMonths(-1);
				case 2: return DateTime.Now.AddDays(-14);
				case 3: return DateTime.Now.AddDays(-7);
				case 4:
				default:
					return DateTime.Now.AddMonths(-1);
			}
		}

		public static List<DateFilterModel> GetTimeRangeFilterValues()
		{
			return new List<DateFilterModel>()
						{
							new DateFilterModel { Text = "1 Month", Value = 1},
							new DateFilterModel { Text = "2 Weeks", Value = 2},
							new DateFilterModel { Text = "1 Week", Value = 3},
							new DateFilterModel { Text = "Generate random data at interval", Value = 4}
						};
		}

		public static bool ShouldForceGeneration(int timeRange)
		{
			return timeRange == 4;
		}

		public static IEnumerable<Issue> GetOpenIssues(IEnumerable<Issue> input)
		{
			return input.Where(x => x.IsOpen == true);
		}

		public static IEnumerable<Issue> GetClosedIssues(IEnumerable<Issue> input)
		{
			return input.Where(x => x.IsOpen == false);
		}

		public static IEnumerable<Issue> GetEnhancements(IEnumerable<Issue> input)
		{
			return input.Where(x => x.Type == IssueType.Enhancement);
		}

		public static IEnumerable<Issue> GetFeatures(IEnumerable<Issue> input)
		{
			return input.Where(x => x.Type == IssueType.Feature);
		}

		public static IEnumerable<Issue> GetLowSevBugs(IEnumerable<Issue> input)
		{
			return  input.Where(x => x.Type == IssueType.Bug && x.Severity == IssueSeverity.Low);
		}

		public static IEnumerable<Issue> GetMedSevBugs(IEnumerable<Issue> input)
		{
			return  input.Where(x => x.Type == IssueType.Bug && x.Severity == IssueSeverity.Medium);
		}

		public static IEnumerable<Issue> GetHighSevBugs(IEnumerable<Issue> input)
		{
			return input.Where(x => x.Type == IssueType.Bug && x.Severity == IssueSeverity.High);
		}
	}
}
