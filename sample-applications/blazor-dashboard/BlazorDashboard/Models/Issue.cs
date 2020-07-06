using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorDashboard.Models
{
	public class Issue
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? ClosedOn { get; set; }
		public string Description { get; set; }
		public IssueType Type { get; set; }
		public IssueSeverity? Severity { get; set; }
		public List<string> Labels { get; set; }
		public bool IsOpen
		{
			get
			{
				return this.ClosedOn.HasValue;
			}
			set
			{
				if (!this.ClosedOn.HasValue)
				{
					this.ClosedOn = DateTime.Now;
				}
			}
		}
	}
}
