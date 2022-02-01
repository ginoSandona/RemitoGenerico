using System.Threading.Tasks;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services
{
    public class AlbVentaCamposLibresService
    {
        private LOGISTICUYContext _context;

        public AlbVentaCamposLibresService(LOGISTICUYContext context)
        {
            _context = context;
        }
        
        public  async Task<Albventacamposlibre> GetSerie(string NumeSerie, int alb)
        {
            Albventacamposlibre obj = await _context.Albventacamposlibres.FirstOrDefaultAsync(c => c.Numserie == NumeSerie && c.Numalbaran == alb);
            return obj;
        }
        
        #region Update Categorias

        public async Task<bool> UpdateRemito(Albventacamposlibre obj)
        {
            bool bandera;
            if (obj != null)
            {
                _context.Albventacamposlibres.Update(obj);
                await _context.SaveChangesAsync();
                bandera= true;
            }
            else
            {
                bandera = false;
            }
            return bandera;
        }
        #endregion
    }
}