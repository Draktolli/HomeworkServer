using Homework5.Entity;
using System.Threading.Tasks;
using System;

namespace Homework5.Repository
{
	public interface IDirectorRepository
	{
		public Task<Guid> Create(Director director);
		public Task<Director> Read(Guid id);
		public Task<Director> Update(Guid id, string name, string surname);
		public Task<Guid?> Delete(Guid id);
	}
}
