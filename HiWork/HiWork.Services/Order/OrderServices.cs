using System;
using System.Collections.Generic;
using System.Linq;
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

        public JsonResult GetOrderDetails(int orderId)
        {
            var result = _context.Order.Join(_context.OrderDetails, x => x.Id, y => y.OrderId,
                (x, y) => new {x = x, y = y}).Where(z => z.y.OrderId == orderId);
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
        JsonResult GetOrderDetails(int orderId);
    }
}
