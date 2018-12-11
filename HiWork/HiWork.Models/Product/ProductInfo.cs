using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiWork.Models.Common;
using HiWork.Models.Order;

namespace HiWork.Models.Product
{
    public class ProductInfo : Entity<int>
    {
        public string ProductName { get; set; }
        public string ProductModel { get; set; }
    }
}
