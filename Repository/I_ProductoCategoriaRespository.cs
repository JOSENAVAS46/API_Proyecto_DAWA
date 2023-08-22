using API_Proyecto_DAWA.Context;
using API_Proyecto_DAWA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Proyecto_DAWA.Repository
{
    public interface I_ProductoCategoriaRepository
    {
        Task<List<ProductoCategoria>> GetAll();
        Task<ProductoCategoria> GetById(int id);
        Task<ProductoCategoria> Create(ProductoCategoria productoCategoria);
        Task<ProductoCategoria> Update(ProductoCategoria productoCategoria);
        Task Delete(int id);
        Task<bool> SaveChanges();
    }

    public class ProductoCategoriaRepository : I_ProductoCategoriaRepository
    {
        private readonly AppDbContext _context;

        public ProductoCategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoCategoria>> GetAll()
        {
            List<ProductoCategoria> lstProductoCategorias = await _context.ProductoCategorias.ToListAsync();
            return lstProductoCategorias;
        }

        public async Task<ProductoCategoria> GetById(int id)
        {
            ProductoCategoria productoCategoria = await _context.ProductoCategorias.FirstOrDefaultAsync(x => x.IdProductoCategoria == id);
            return productoCategoria;
        }

        public async Task<ProductoCategoria> Create(ProductoCategoria productoCategoria)
        {
            _context.ProductoCategorias.Add(productoCategoria);
            await _context.SaveChangesAsync();
            return productoCategoria;
        }

        public async Task<ProductoCategoria> Update(ProductoCategoria productoCategoria)
        {
            var existingProductoCategoria = await _context.ProductoCategorias.FindAsync(productoCategoria.IdProductoCategoria);

            if (existingProductoCategoria != null)
            {
                _context.Entry(existingProductoCategoria).CurrentValues.SetValues(productoCategoria);
                await _context.SaveChangesAsync();
                return existingProductoCategoria;
            }
            else
            {
                throw new InvalidOperationException("El ProductoCategoria con el Id especificado no existe en el contexto.");
            }
        }

        public async Task Delete(int id)
        {
            var existingProductoCategoria = await _context.ProductoCategorias.FindAsync(id);

            if (existingProductoCategoria != null)
            {
                _context.ProductoCategorias.Remove(existingProductoCategoria);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("El ProductoCategoria con el Id especificado no existe en el contexto.");
            }
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
