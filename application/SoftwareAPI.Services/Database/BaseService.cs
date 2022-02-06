using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftwareAPI.Database;
using SoftwareAPI.Database.Models;

namespace SoftwareAPI.Services.Database
{
    public abstract class BaseService<TEntity> where TEntity : BaseModel
    {	
		protected BaseService(SoftwareAPIDbContext dbContext, IMapper mapper)
		{
			this.DbContext = dbContext;
			this.DbSet = dbContext.Set<TEntity>();
			this.Mapper = mapper;
		}

		protected SoftwareAPIDbContext DbContext { get; private set; }

		protected DbSet<TEntity> DbSet { get; private set; }

		protected IMapper Mapper { get; private set; }
	}
}
