using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Database.Models.Base;

namespace WebApi.Database.Repositories.Base
{
    public interface IBaseRepository<Tmodel> where Tmodel:class,IBaseModel
    {
        Task<IEnumerable<Tmodel>> GetAll();
        Task<IEnumerable<Tmodel>> GetAllWhere(Expression<Func<Tmodel,bool>> @where);
        Task<Tmodel> GetWhere(Expression<Func<Tmodel,bool>> @where);
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

        public virtual async Task<IEnumerable<Tmodel>> GetAll()
        {
            return await Task.Run(()=> Conection.Set<Tmodel>());
        }

        public virtual async Task<IEnumerable<Tmodel>> GetAllWhere(Expression<Func<Tmodel, bool>> where)
        {
            return await Task.Run(()=>Conection.Set<Tmodel>().Where(where));
        }

        public virtual async Task<Tmodel> GetByID(object id)
        {
            return await Conection.Set<Tmodel>().FindAsync(id);
        }

        public virtual async Task<Tmodel> GetWhere(Expression<Func<Tmodel, bool>> where)
        {
            return await Conection.Set<Tmodel>().FirstAsync();
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
