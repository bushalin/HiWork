using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiWork.Models.Common;

namespace HiWork.Models.Customer
{
    public class Customer : Entity<int>
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string MobileNo { get; set; }
    }
}
