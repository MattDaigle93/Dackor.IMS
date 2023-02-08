﻿using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMSContext db;

        public ProductRepository(IMSContext db)
        {
            this.db = db;
        }

        public async Task AddProductAsync(Product product)
        {
            if (db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase))) return;

            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await db.Products.Include(x => x.ProductInventories)
                .ThenInclude(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            return await this.db.Products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                                   string.IsNullOrWhiteSpace(name)).ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            //prevent same name
            if (db.Products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
            return;

            var prod = await db.Products.FindAsync(product.ProductId);
            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.Price = product.Price;
                prod.Quantity = product.Quantity;
                prod.ProductInventories = product.ProductInventories;

                await db.SaveChangesAsync();
            }
        }
    }
}
