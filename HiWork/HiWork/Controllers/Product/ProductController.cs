using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HiWork.Models.Product;
using HiWork.Services.Product;

namespace HiWork.Controllers.Product
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductServices _services;
        public ProductController()
        {
            _services = new ProductServices();
        }

        // Fetch all products from the database
        [Route("GetAllProductList")]
        [HttpGet]
        public IHttpActionResult GetAllProductList()
        {

            return Ok(_services.GetAllProductList().Data);
        }

        [Route("GetProductById/{productId:int}")]
        [HttpGet]
        public IHttpActionResult GetProductById(int productId)
        {
            return Ok(_services.GetProductInfoById(productId));
        }

        [Route("SaveProduct")]
        [HttpPost]
        public IHttpActionResult SaveUser(ProductInfo obj)
        {
            return Ok(_services.SaveProduct(obj).Data);
        }
    }
}
