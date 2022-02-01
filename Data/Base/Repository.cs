using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities.Model;
using Microsoft.EntityFrameworkCore;


namespace Data.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LOGISTICUYContext dbContext;

        public Repository(LOGISTICUYContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<T> RetrieveAll()
        {
            return dbContext.Set<T>();
        }
        public T Retrieve(object[] parameters)
        {
            return dbContext.Set<T>().Find(parameters);
        }

        public async Task<T> RetrieveAsync(object[] parameters)
        {
            return await dbContext.Set<T>().FindAsync(parameters);
        }

        public void Update(T obj)
        {
            dbContext.Set<T>().Attach(obj);
            dbContext.Entry(obj).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T obj)
        {
            dbContext.Set<T>().Attach(obj);
            dbContext.Entry(obj).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Create(T obj)
        {
            dbContext.Set<T>().Add(obj);
            dbContext.SaveChanges();
        }

        public async Task CreateAsync(T obj)
        {
            await dbContext.Set<T>().AddAsync(obj);
            await dbContext.SaveChangesAsync();
        }

        public void Remove(T obj)
        {
            dbContext.Set<T>().Remove(obj);
            dbContext.SaveChanges();
        }

        public async Task<List<Albventacamposlibre>> getAllTask()
        {
            //Relaciono la busqueda de AlbVentasCampoLibres con las otras entidades relacionadas. Para ello uso .Include y ThenInclude
            return await dbContext.Albventacamposlibres.Include(x=>x.NNavigation).ThenInclude(x=>x.Albventalins).Where(x => x.Replicado =="F").ToListAsync();
        }

        

        public IQueryable<T> Set => dbContext.Set<T>();
    }
}