using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketEngineProductBAL
{
     public interface IProductService
    {
        IList<ProductBusinessModel> GetAllProducts();
        ProductBusinessModel GetProductDetails(int productID);
        int Add(ProductBusinessModel newPoduct);
        int Update(ProductBusinessModel product);
    }
}
