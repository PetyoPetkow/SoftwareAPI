namespace SoftwareAPI.Services.Database
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SoftwareAPI.Database;
    using SoftwareAPI.DTOs.Type;
    using SoftwareAPI.Services.Database.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TypeService : BaseService<SoftwareAPI.Database.Models.Software.Type>, ITypeService
    {
        public TypeService(SoftwareAPIDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<T> GetAllAsync<T>()
        {
            IEnumerable<SoftwareAPI.Database.Models.Software.Type> types = await this.DbSet
                .OrderBy(t => t.Name)
                .ToListAsync();
            T result = this.Mapper.Map<T>(types);
            return result;
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
        {
            SoftwareAPI.Database.Models.Software.Type type = await this.DbSet
                .SingleOrDefaultAsync(t =>t.Id == id);

            T result = this.Mapper.Map<T>(type);
            return result;
        }

        public async Task<T> AddAsync<T>(PostTypeDTO model)
        {
            SoftwareAPI.Database.Models.Software.Type typeToAdd = this.Mapper.Map<SoftwareAPI.Database.Models.Software.Type>(model);

            await this.DbSet.AddAsync(typeToAdd);
            await this.DbContext.SaveChangesAsync();
            T result = this.Mapper.Map<T>(typeToAdd);
            return result;
        }

        public async Task<bool> UpdateAsync(Guid id, PutTypeDTO model)
        {
            SoftwareAPI.Database.Models.Software.Type typeToUpdate = await this.DbSet
                .FindAsync(id);
            if (typeToUpdate == null)
            {
                return false;
            }
            SoftwareAPI.Database.Models.Software.Type updatedType = this.Mapper.Map(model, typeToUpdate);
            updatedType.UpdatedOn = DateTime.UtcNow;
            this.DbSet.Update(updatedType);
            await this.DbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            SoftwareAPI.Database.Models.Software.Type typeToDelete = await this.DbSet
                .FindAsync(id);
            if (typeToDelete == null)
            {
                return false;
            }
            this.DbContext.Remove(typeToDelete);
            await this.DbContext.SaveChangesAsync();
            return true;
        }
    }
}
