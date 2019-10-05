using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Database.Models.Base;

namespace WebApi.Database.Repositories.Base
{
    public interface IBaseRepository<Tmodel> where Tmodel:class,IBaseModel
    {
        Task<List<Tmodel>> GetAll();
        Task<Tmodel> GetByID(object id);
        Task Insert(Tmodel model);
        Task Update(Tmodel model);
        Task Delete(Tmodel model);
    }
    public class BaseRepository<Tmodel> : IBaseRepository<Tmodel> where Tmodel : class,IBaseModel
    {
        public readonly DatabaseConection Conection;
        public BaseRepository(DatabaseConection conection)
        {
            Conection = conection;
        }
        public virtual async Task Delete(Tmodel model)
        {
            try
            {
                Conection.Set<Tmodel>().Remove(model);
                await Conection.SaveChangesAsync();
            }
            catch (Exception exe)
            {

                throw exe;
            }
        }

        public virtual async Task<List<Tmodel>> GetAll()
        {
            return await Task.Run(()=> Conection.Set<Tmodel>().ToList());
        }

        public virtual async Task<Tmodel> GetByID(object id)
        {
            return await Conection.Set<Tmodel>().FindAsync(id);
        }

        public virtual async Task Insert(Tmodel model)
        {
            try
            {
                await Conection.Set<Tmodel>().AddAsync(model);
                await Conection.SaveChangesAsync();
            }
            catch (Exception exe)
            {

                throw exe;
            }
        }

        public virtual async Task Update(Tmodel model)
        {
            try
            {
                Conection.Entry(model).State = EntityState.Modified;
                await Conection.SaveChangesAsync();
            }
            catch (Exception exe)
            {
                throw exe;
            }
        }
    }
}
