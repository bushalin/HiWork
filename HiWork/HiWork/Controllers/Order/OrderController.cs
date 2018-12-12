using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HiWork.Services.Order;

namespace HiWork.Controllers.Order
{
    [RoutePrefix("Api/Order")]
    public class OrderController : ApiController
    {
        private readonly IOrderServices _services;
        public OrderController()
        {
            _services = new OrderServices();
        }

        [Route("GetOrderById/{orderId:int}")]
        [HttpGet]
        public IHttpActionResult GetOrderById(int orderId)
        {
            return Ok(_services.GetOrderById(orderId));
        }

        [Route("GetOrderDetailsById/{orderId:int}")]
        [HttpGet]
        public IHttpActionResult GetOrderDetailsById(int orderId)
        {
            return Ok(_services.GetOrderDetailsById(orderId));
        }
    }
}
