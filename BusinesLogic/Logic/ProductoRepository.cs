using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Logic
{
    public class ProductoRepository : IProductoRepository

    {
        Task<IReadOnlyList<Producto>> IProductoRepository.GetProdcutosAsync()
        {
            throw new NotImplementedException();
        }

        Task<Producto> IProductoRepository.GetProductoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
