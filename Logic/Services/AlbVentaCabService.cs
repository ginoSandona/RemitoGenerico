using System.Threading.Tasks;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services
{
    public class AlbVentaCabService
    {
        private LOGISTICUYContext _context;

        public AlbVentaCabService(LOGISTICUYContext context)
        {
            _context = context;
        }
        
        public  async Task<Albventacab> GetSerie(string NumeSerie, int alb)
        {
            Albventacab obj = await _context.Albventacabs.FirstOrDefaultAsync(c => c.Numserie == NumeSerie && c.Numalbaran == alb);
            return obj;
        }
        
        
    }
}