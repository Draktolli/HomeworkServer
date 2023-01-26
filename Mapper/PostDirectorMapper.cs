using Homework5.Entity;
using Homework5Client.DTO;
using System;

namespace Homework5.Mapper
{
	public class PostDirectorMapper : IPostDirectorMapper
	{
		public Director Map(PostDirectorRequest postDirectorRequest)
		{
			return new Director
			{
				Id = Guid.NewGuid(),
				Name = postDirectorRequest.Name,
				SurName = postDirectorRequest.SurName,
				School = postDirectorRequest.School
			};
		}
	}
}
