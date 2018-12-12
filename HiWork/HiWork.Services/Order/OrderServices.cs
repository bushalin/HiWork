using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HiWork.Models;
using HiWork.Models.Product;

namespace HiWork.Services.Order
{
    public class OrderServices : IOrderServices
    {
        private readonly HiWorkDbContext _context;
        private readonly IEntityService<Models.Order.Order> _services;
        public OrderServices()
        {
            _context = new HiWorkDbContext();
            _services = new EntityService<Models.Order.Order>(_context);
        }

        public JsonResult GetOrderDetailsById(int orderId)
        {
            var result = _context.Order.Where(o => o.Id == orderId)         //find the data from order which have the same id as orderId
                .Join(_context.User,                                        //joining the two tables
                    o => o.UserId,                                          //order table foreign key
                    u => u.Id,                                              //user table primary key
                    (o, u) => new {Order = o, User = u})                    //defining name as order = o and user = u
                .Select(x => new                                            //now selecting all the data that have the orderId and gathering those data in another table defined by x
                {
                    x.Order.OrderAmount,
                    x.User.FirstName,
                    x.User.LastName,                                        //selecting the values that need to be saved
                    x.User.Address,
                    x.User.Email,
                    x.User.Gender,
                    x.User.Mobile,

                    OrderDetail = _context.OrderDetails.Where(od => od.OrderId == x.Order.Id)           //now selecting the data for joining the tables OrderDetails and Order
                        .Join(_context.Product,                                                         //joining the two tables order and productinfo
                            od => od.ProductInfoId,                                                     //defining the pk and fk
                            p => p.Id,
                            (od, p) => new {OrderDetail = od, Product = p})                             //renaming those tables as such
                        .Select(k => new                                                                //selecting and gathering data on a new table k, where we have the selected order details
                        {
                            k.Product.ProductModel,                                                     //selecting the product information
                            k.Product.ProductName
                        }).ToList()                                                                     //one order can have multiple products so it is a list
                }).FirstOrDefault();                                                                    //order itself is a singular order, so it is a singular data

            return new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetOrderById(int orderId)
        {
            var result = _context.Order.Where(x => x.Id == orderId).Select(u=>new
            {
                u.OrderAmount,
                u.UserId,
                u.CreatedBy,
                u.CreatedDate
            }).FirstOrDefault();
            return new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }

    public interface IOrderServices
    {
        JsonResult GetOrderById(int orderId);
        JsonResult GetOrderDetailsById(int orderId);
    }
}
