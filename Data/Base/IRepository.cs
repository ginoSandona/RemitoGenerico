using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Model;


namespace Data.Base
{
    public interface IRepository<T>
    {
        T Retrieve(object[] parameters);

        Task<T> RetrieveAsync(object[] parameters);

        void Update(T obj);

        Task UpdateAsync(T obj);

        void Create(T obj);

        Task CreateAsync(T obj);

        void Remove(T obj);

        Task<List<Albventacamposlibre>> getAllTask();
        
        
        
        IQueryable<T> Set { get; }
    }
}