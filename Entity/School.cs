using System.Collections.Generic;
using System;

namespace Homework5.Entity
{
	public record School
	{
		public Guid Id { get; set; }
		public int Number { get; set; }
		public Guid DirectorId { get; set; }
		public Director Director { get; set; }
		public ICollection<Class> Classes { get; set; } = new HashSet<Class>();
		public ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
	}
}
