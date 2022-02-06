namespace SoftwareAPI.Services.Database
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using SoftwareAPI.Database;
    using SoftwareAPI.Database.Models.Software;
    using SoftwareAPI.DTOs.Utility;
    using SoftwareAPI.Services.Database.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    public class UtilityService : BaseService<Utility>, IUtilityService
    {
        public UtilityService(SoftwareAPIDbContext dbContext, IMapper mapper)
             : base(dbContext, mapper)
        {

        }

        public async Task<T> AddAsync<T>(PostUtilityDTO utility)
        {
            Utility utilityToAdd = this.Mapper.Map<Utility>(utility);

            await this.DbSet.AddAsync(utilityToAdd);
            await this.DbContext.SaveChangesAsync();

            T utilityToReturn = this.Mapper.Map<T>(utilityToAdd);

            return utilityToReturn;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Utility utilityToDelete = await this.GetByIdAsync<Utility>(id);

            if (utilityToDelete == null)
            {
                throw new Exception();
            }

            utilityToDelete.IsDeleted = true;
            utilityToDelete.DeletedOn = DateTime.UtcNow;

            this.DbSet.Update(utilityToDelete);
            int resultFromDb = await this.DbContext.SaveChangesAsync();

            bool result = resultFromDb != 0;
            return result;
        }

        public async Task<T> GetAllAsync<T>()
        {
            List<Utility> utilities = await this.DbSet
                .OrderBy(u => u.Name)
                .ThenBy(u => u.Publisher)
                .ToListAsync();

            T mappedUtilities = this.Mapper.Map<T>(utilities);
            return mappedUtilities;
        }

        public async Task<T> GetByIdAsync<T>(Guid id)
        {
            Utility utility = await this.DbSet
                .SingleOrDefaultAsync(u => u.Id == id);

            T mappedUtility = this.Mapper.Map<T>(utility);

            return mappedUtility;
        }

        public async Task<bool> PartialUpdateAsync(Guid id, PatchUtilityDTO utility)
        {
            Utility utilityToUpdate = await this.GetByIdAsync<Utility>(id);

            if (utilityToUpdate == null)
            {
                return false;
            }
            System.Type modelType = utility.GetType();
            PropertyInfo[] properties = modelType.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                var propertyValue = propertyInfo.GetValue(utility);
                if (propertyValue != null)
                {
                    System.Type utilityToUpdateType = utilityToUpdate.GetType();
                    PropertyInfo propertyToUpdate = utilityToUpdateType.GetProperty(propertyInfo.Name);
                    propertyToUpdate.SetValue(utilityToUpdate, propertyValue);
                }
            }
            utilityToUpdate.UpdatedOn = DateTime.UtcNow;

            this.DbContext.Update(utilityToUpdate);
            await this.DbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, PutUtilityDTO utility)
        {
            Utility utilityToUpdate = await this.GetByIdAsync<Utility>(id);

            if (utilityToUpdate == null)
            {
                return false;
            }
            Utility updatedUtility = this.Mapper.Map(utility, utilityToUpdate);
            updatedUtility.UpdatedOn = DateTime.UtcNow;
            this.DbContext.Update(updatedUtility);
            await this.DbContext.SaveChangesAsync();

            return true;
        }
    }
}
