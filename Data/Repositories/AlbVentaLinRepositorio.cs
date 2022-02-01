using Data.Base;
using Entities.Model;

namespace Data.Repositories
{
    public class AlbVentaLinRepositorio : Repository<Albventalin>
    {
        public AlbVentaLinRepositorio(LOGISTICUYContext dbContext) : base(dbContext)
        {
        }
    }
}