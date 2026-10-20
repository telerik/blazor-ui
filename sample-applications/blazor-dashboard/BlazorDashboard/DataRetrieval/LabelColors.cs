using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDashboard.DataRetrieval
{
	public static class LabelColors
	{
		public static string GetClass(string label)
		{
			label = label.ToLowerInvariant();
			return label switch
			{
				"bug" or "high" => "issue-label--error",
				"feature" or "enhancement" => "issue-label--success",
				"low" => "issue-label--warning",
				"medium" => "issue-label--tertiary",
				_ => "issue-label--info"
			};
		}
	}
}
