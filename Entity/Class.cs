using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Homework5.Entity
{
	[Table("Classes")]
	public record Class
	{
		public Guid Id { get; set; }
		public int number { get; set; }
		public string liter { get; set; }
		public Guid? SchoolId { get; set; }
		public School? School { get; set; }
		public ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
	}
}
