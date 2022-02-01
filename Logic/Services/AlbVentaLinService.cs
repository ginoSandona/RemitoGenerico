using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services
{
    public class AlbVentaLinService
    {
        private LOGISTICUYContext _context;

        public AlbVentaLinService(LOGISTICUYContext context)
        {
            _context = context;
        }
        //
        // public  async Task<List<Albventalin>> GetSerie(string NumeSerie, int alb)
        // {
        //     List<Albventalin> obj = await _context.Albventalins.ToListAsync(c => c.Numserie == NumeSerie && c.Numalbaran == alb);
        //     return obj;
        // }
        //
        // public async Task<List<Albventalin>> GetAll(string NumeSerie, int alb)
        // {
        //     return await _context.Albventalins.ToListAsync(c => c.Numserie == NumeSerie && c.Numalbaran == alb);
        // }
    }
}