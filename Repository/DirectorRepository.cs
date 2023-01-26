using Homework5.DB;
using Homework5.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Homework5.Repository
{
	public class DirectorRepository : IDirectorRepository
	{
		private readonly DBContext _dbContext;
		public DirectorRepository(DBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Guid> Create(Director director)
		{
			_dbContext.Directors.Add(director);
			await _dbContext.SaveChangesAsync();
			return director.Id;
		}

		public async Task<Director> Read(Guid id)
		{ 
			try
			{ 
				var director = await (from d in _dbContext.Directors
					where d.Id == id
					select d).FirstOrDefaultAsync();
				return director;
			}
			catch
			{
				return null;
			}
		}
		

		public async Task<Director> Update(Guid id, string name, string surname)
		{ 
			var director = await (from d in _dbContext.Directors
						where d.Id == id
						select d
						).FirstOrDefaultAsync();
			if (director == null)
			{
				return null;

			}
			director.Name = name;
			director.SurName = surname;
			await _dbContext.SaveChangesAsync();
			return director;
			
			
		}

		public async Task<Guid?> Delete(Guid id)
		{
			try
			{ 
				var director = await (from d in _dbContext.Directors
						where d.Id == id
						select d
						).FirstOrDefaultAsync();
				_dbContext.Remove(director);
				await _dbContext.SaveChangesAsync();
				return id;
			}
			catch
			{
				return null;
			}
		}
	}
}
