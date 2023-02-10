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
    public class ProductTransactionRepository : IProductTransactionRepository
    {
        private readonly IMSContext db;

        public ProductTransactionRepository(IMSContext db, IProductRepository productRepository)
        {
            this.db = db;
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; }

        public async Task ProduceAsync(string productionNumber, Product product, int quantity, double price, string doneBy)
        {
            //var prod = this.ProductRepository.GetProductByIdAsync(product.ProductId);
            var prod = await db.Products
                .Include(x => x.ProductInventories)
                .ThenInclude(x => x.Inventory)
                .FirstOrDefaultAsync(x => x.ProductId == product.ProductId);
            if (prod != null)
            {
                foreach(var pi in prod.ProductInventories)
                {
                    pi.Inventory.Quantity -= quantity * pi.InventoryQuantity;
                }
            }

            this.db.ProductTransactions.Add(new ProductTransaction
            {
                ProductionNumber = productionNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                ActivityType = ProductTransactionType.ProduceProduct,
                QuantityAfter = product.Quantity + quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });
            await this.db.SaveChangesAsync();
        }

        public async Task SellProductAsync(string salesOrderNumber, Product product, int quantity, double price, string doneBy)
        {
            this.db.ProductTransactions.Add(new ProductTransaction
            {
                SalesOrderNumber = salesOrderNumber,
                ProductId = product.ProductId,
                QuantityBefore = product.Quantity,
                QuantityAfter = product.Quantity - quantity,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });
            await this.db.SaveChangesAsync();
        }
    }
}
