using Data.Base;

using Entities.Model;

namespace Data.Repositories
{
    public class AlbVentaCampoLibreRepositorio : Repository<Albventacamposlibre>
    {
        public AlbVentaCampoLibreRepositorio(LOGISTICUYContext dbContext) : base(dbContext)
        {
            
        }
    }
}