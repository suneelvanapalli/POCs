using AutoMapper;
using MarketEngineProductBAL;
using MarketEngineProductMaintenance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketEngineProductMaintenance.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }


        public ActionResult Index()
        {
            var productList = _productService.GetAllProducts();
            var mapper = GetMapper<ProductBusinessModel, ProductViewModel>();
           var productViewModelList = productList.Select(p => mapper.Map<ProductBusinessModel, ProductViewModel>(p)).ToList();
           return View(productViewModelList);
        }

        public ActionResult Details(int id)
        {
            var productDetails = _productService.GetProductDetails(id);
            var mapper = GetMapper<ProductBusinessModel, ProductViewModel>();
            var product = mapper.Map<ProductBusinessModel, ProductViewModel>(productDetails);
            return View(product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var productViewModel = new ProductViewModel();
            return View(productViewModel);

        }

        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            var mapper = GetMapper<ProductViewModel, ProductBusinessModel>();
            var product = mapper.Map<ProductViewModel, ProductBusinessModel>(productViewModel);
            _productService.Add(product);
            return View();

        }

        [HttpGet]
        public ActionResult Update(int productId)
        {
            var productDetails = _productService.GetProductDetails(productId);
            var mapper = GetMapper<ProductBusinessModel, ProductViewModel>();
            var product = mapper.Map<ProductBusinessModel, ProductViewModel>(productDetails);
            return View(product);
        }


        [HttpPost]
        public ActionResult Update(ProductViewModel productViewModel)
        {
            var mapper = GetMapper<ProductViewModel, ProductBusinessModel>();
            var product = mapper.Map<ProductViewModel, ProductBusinessModel>(productViewModel);
            _productService.Update(product);
            return View();
        }




        private IMapper GetMapper<TSource, TDest>()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDest>());
            return config.CreateMapper();
        }
    }
}