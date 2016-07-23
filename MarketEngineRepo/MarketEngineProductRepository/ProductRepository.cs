using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MarketEngineProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private MarketEngineProductRepository.MarketEngineDBConnectionString dbContext;

        public ProductRepository()
        {
            dbContext = new MarketEngineDBConnectionString();
        }

        public List<Product> GetAllProducts()
        {
            return dbContext.Products.ToList();
        }

        public Product GetProductDetails(int productID)
        {
            return dbContext.Products.FirstOrDefault(x => x.Id == productID);
        }

        public int Add(Product newPoduct)
        {
            var product = dbContext.Products.Add(newPoduct);
            Save();
            return product.Id;

        }

        public int Update(Product product)
        {
            dbContext.Entry(product).State = EntityState.Modified;
            Save();
            return product.Id;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
