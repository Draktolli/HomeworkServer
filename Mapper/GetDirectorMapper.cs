using Homework5.Entity;
using Homework5Client.DTO;

namespace Homework5.Mapper
{
	public class GetDirectorMapper : IGetDirectorMapper
	{
		public GetDirectorResponse Map(Director director)
		{
			return new GetDirectorResponse
			{
				Id = director.Id,
				Name = director.Name,
				SurName = director.SurName,
				School = director.School,
			};
		}
	}
}
