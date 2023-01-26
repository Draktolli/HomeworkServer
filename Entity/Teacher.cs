using System.Collections.Generic;
using System;

namespace Homework5.Entity
{
	public record Teacher
	{
		public Guid Id { get; set; }
		public string name { get; set; }
		public string surname { get; set; }
		public Guid? SchoolId { get; set; }
		public School? School { get; set; }
		public ICollection<Class> Сlasses { get; set; } = new HashSet<Class>();
	}
}
