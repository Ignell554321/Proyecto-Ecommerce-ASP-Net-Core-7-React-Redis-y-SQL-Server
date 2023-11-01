using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductoRepository
    {

        public Task<Producto> GetProductoByIdAsync(int id);
        Task<IReadOnlyList<Producto>> GetProdcutosAsync(); 

    }
}
