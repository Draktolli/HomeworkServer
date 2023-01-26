using Homework5.DTO;
using Homework5.Entity;
using Homework5Client.DTO;

namespace Homework5.Mapper
{
	public class UpdateDirectorMapper : IUpdateDirectorMapper
	{
		public UpdateDirectorResponse Map(Director director)
		{
			return new UpdateDirectorResponse
			{
				Id = director.Id,
				Name = director.Name,
				SurName = director.SurName,
				School = director.School
			};
		}
	}
}
