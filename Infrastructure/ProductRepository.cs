using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
    {
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
            .Include(p=>p.ProductType)
            .Include(p=>p.ProductType)
            .ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
               return await _context.Products
                 .Include(p=>p.ProductBrand) // posto je eager loading da bi se ukljucila polja iz drugih tabela
                 .Include(p=>p.ProductType)
                 .SingleOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        {
            return await _context.ProductBrands.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
             return await _context.ProductBrands.ToListAsync();
        }

        public async Task<ProductType> GetProductTypesByIdAsync(int id)
        {
           return await _context.ProductTypes.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}