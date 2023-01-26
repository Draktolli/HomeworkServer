using System;

namespace Homework5.Entity
{
	public class ClassesTeachers
	{
		public Guid ClassId { get; set; }
		public Class Class { get; set; }
		public Guid TeacherId { get; set; }
		public Teacher Teacher { get; set; }
	}
}
