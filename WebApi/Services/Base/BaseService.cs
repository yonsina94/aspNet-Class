using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Database.Models.Base;
using WebApi.Database.Repositories.Base;

namespace WebApi.Services.Base{
    public interface IBaseService<Tmodel> where Tmodel:BaseModel
    {
        Task<List<Tmodel>> GetAllAsync();
        Task<Tmodel> GetByIDAsync(object id);
        Task<bool> InsertAsync(Tmodel model);
        Task<bool> UpdateAsync(Tmodel model);
        Task<bool> DeleteAsync(Tmodel model);
        Task<bool> DeleteAsync(object id);

        Task<bool> ValidateOnCreateAsync(Tmodel model);
        Task<bool> ValidateOnUpdateAsync(Tmodel model);
        Task<bool> ValidateOnDeleteAsync(Tmodel model);
    }

    public abstract class BaseService<Tmodel> : IBaseService<Tmodel> where Tmodel : BaseModel
    {
        protected readonly IBaseRepository<Tmodel> Repository;
        public BaseService(IBaseRepository<Tmodel> repository)
        {
            Repository = repository;
        }

        public virtual async Task<bool> DeleteAsync(Tmodel model)
        {
            try
            {
                var result = await ValidateOnDeleteAsync(model);
                if(result){
                    await Repository.Delete(model);
                    return true;
                } else{
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            try
            {
                var model = await Repository.GetByID(id);
                var result = await ValidateOnDeleteAsync(model);
                if(result){
                    await Repository.Delete(model);
                    return true;
                } else {
                    return false;
                }
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }

        public virtual async Task<List<Tmodel>> GetAllAsync()
        {
            return (await Repository.GetAll()).ToList();
        }

        public virtual async Task<Tmodel> GetByIDAsync(object id)
        {
            return await Repository.GetByID(id);
        }

        public virtual async Task<bool> InsertAsync(Tmodel model)
        {
            try
            {
                var result = await ValidateOnCreateAsync(model);
                if(result){
                    await Repository.Insert(model);
                    return true;
                } else {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<bool> UpdateAsync(Tmodel model)
        {
            try
            {
                var result = await ValidateOnUpdateAsync(model);
                if(result){
                    await Repository.Update(model);
                    return true;
                } else {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public abstract Task<bool> ValidateOnCreateAsync(Tmodel model);

        public abstract Task<bool> ValidateOnDeleteAsync(Tmodel model);

        public abstract Task<bool> ValidateOnUpdateAsync(Tmodel model);
    }
}