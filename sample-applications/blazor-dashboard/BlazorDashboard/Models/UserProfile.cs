using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDashboard.Models
{
	public class UserProfile
	{
		[Required, Range(1, int.MaxValue)]
		public int Id { get; set; }

		[Required(ErrorMessage = "You must have a login name.")]
		public string Login { get; set; }

		[Required(ErrorMessage = "A name is required.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "An email is required")]
		[EmailAddress(ErrorMessage = "Please provide a valid email address.")]
		public string PublicEmail { get; set; }

		public bool PrivateEmail { get; set; }

		public string Company { get; set; }

		public string Location { get; set; }

		[DataType(DataType.Url)]
		public string AvatarUrl { get; set; }
	}
}
