using Homework5.Entity;
using Homework5Client.DTO;

namespace Homework5.Mapper
{
	public interface IPostDirectorMapper
	{
		public Director Map(PostDirectorRequest postDirectorRequest);
	}
}
