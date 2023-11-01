using BusinesLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Logic
{
    public class ProductoRepository : IProductoRepository

    {
        private readonly MarketDbContext _context;
        public ProductoRepository(MarketDbContext conetxt) {

            _context = conetxt;

        }

        public async Task<IReadOnlyList<Producto>> GetProdcutosAsync()
        {
            return await _context.Producto//.ToListAsync();
                .Include(p=>p.Marca)
                .Include(p=>p.Categoria)
                .ToListAsync();
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {

            return await _context.Producto//.FindAsync(id);
               .Include(p => p.Marca)
               .Include(p => p.Categoria)
               .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
