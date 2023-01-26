using Homework5.Entity;
using Homework5Client.DTO;

namespace Homework5.Mapper
{
	public interface IGetDirectorMapper
	{
		public GetDirectorResponse Map(Director director);
	}
}
