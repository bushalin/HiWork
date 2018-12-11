using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiWork.Models.Common;
using HiWork.Models.Product;

namespace HiWork.Models.Order
{
    public class OrderDetails : Entity<int>
    {
        public int ProductInfoId { get; set; }
        [ForeignKey("ProductInfoId")]
        public virtual ProductInfo ProductInfo { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
