using Data.Base;
using Entities.Model;

namespace Data.Repositories
{
    public class AlbVentaCabRepositorio : Repository<Albventacab>
    {
        public AlbVentaCabRepositorio(LOGISTICUYContext dbContext) : base(dbContext)
        {
            
        }
    }
}