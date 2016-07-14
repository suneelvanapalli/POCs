using AutoMapper;
using MarketEngineProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketEngineProductBAL
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            //implementing contructor injection using IOC Container(Autofac)
            _productRepository = productRepository;
        }

        public IList<ProductBusinessModel> GetAllProducts()
        {
            var productList = _productRepository.GetAllProducts();
            var mapper = GetMapper<Product, ProductBusinessModel>();
            //var product = mapper.Map<Product, ProductBusinessModel>(productList);

            var productBusinessModelList = productList.Select(p => mapper.Map<Product, ProductBusinessModel>(p)).ToList();
            return productBusinessModelList;
        }

        public ProductBusinessModel GetProductDetails(int productID)
        {
            var product = _productRepository.GetProductDetails(productID);
            var mapper = GetMapper<Product, ProductBusinessModel>();

            return mapper.Map<Product, ProductBusinessModel>(product);
        }

        public int Add(ProductBusinessModel newProduct)
        {
            var mapper = GetMapper<ProductBusinessModel, Product>();
            var product = mapper.Map<ProductBusinessModel, Product>(newProduct);

            return _productRepository.Add(product);
        }

        public int Update(ProductBusinessModel product)
        {

            var mapper = GetMapper<ProductBusinessModel, Product>();
            var productToUpdate = mapper.Map<ProductBusinessModel, Product>(product);
            return _productRepository.Update(productToUpdate);
        }


        private IMapper GetMapper<TSource, TDest>()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>());
            return config.CreateMapper();
        }

    }
}
