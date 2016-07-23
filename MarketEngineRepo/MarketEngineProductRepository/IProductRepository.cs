using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketEngineProductRepository
{
   public interface IProductRepository : IDisposable
    {
        List<Product> GetAllProducts();
        Product GetProductDetails(int productID);
        int Add(Product newPoduct);
        int Update(Product product);       
    }
}
