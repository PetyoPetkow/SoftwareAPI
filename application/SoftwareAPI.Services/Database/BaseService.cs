using Microsoft.EntityFrameworkCore;
using SoftwareAPI.Database;
using SoftwareAPI.Database.Models;

namespace SoftwareAPI.Services.Database
{
    public abstract class BaseService<TEntity> where TEntity : BaseModel
    {	
		protected BaseService(SoftwareAPIDbContext dbContext)
		{
			this.DbContext = dbContext;
			this.DbSet = dbContext.Set<TEntity>();
		}

		protected SoftwareAPIDbContext DbContext { get; private set; }

		protected DbSet<TEntity> DbSet { get; private set; }
	}
}
