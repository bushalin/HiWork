using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HiWork.Common;
using HiWork.Models;
using HiWork.Models.Product;
using HiWork.Models.SP_User;

namespace HiWork.Services.Product
{
    public class ProductServices : IProductServices
    {
        private readonly HiWorkDbContext _context;
        private readonly IEntityService<ProductInfo> _services;
        public ProductServices()
        {
            _context = new HiWorkDbContext();
            _services = new EntityService<ProductInfo>(_context);
        }

        private bool IsProductFound(ProductInfo obj)
        {
            var result = _context.Product
                .Where(p => p.ProductName == obj.ProductName && p.ProductModel == obj.ProductModel).Select(x => x.Id)
                .FirstOrDefault();

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public JsonResult GetAllProductList()
        {
            var productList = _services.GetAll().ToList();

            return new JsonResult
            {
                Data = productList,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetProductInfoById(int productId)
        {
            var result = _context.Product.Where(u => u.Id == productId)
                .Select(u => new
                {
                    u.Id,
                    u.ProductName,
                    u.ProductModel
                }).FirstOrDefault();

            return new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult SaveProduct(ProductInfo obj)
        {
            var message = "";

            if (obj.ProductName == null || obj.ProductModel == null)
            {
                message = "You did not provide product name!";
                Generator.IsReport = "Warning";
            }
            else if (IsProductFound(obj))
            {
                message = "Product already exists ! Please add another product.";
                Generator.IsReport = "Warning";
            }
            else
            {
                try
                {
                    _services.Save(obj);
                    _services.SaveChanges();
                    message = "Product saved successfully !";
                    Generator.IsReport = "Ok";

                }
                catch (Exception ex)
                {
                    //message = "Something went wrong ! Please contact system administrator.";
                    message = ex.Message;
                    Generator.IsReport = "NotOk";
                }
            }
            return new JsonResult
            {
                Data = new
                {
                    Message = message,
                    Generator.IsReport

                },

                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }

    public interface IProductServices
    {
        JsonResult GetAllProductList();
        JsonResult GetProductInfoById(int productId);
        JsonResult SaveProduct(ProductInfo obj);
    }
}
