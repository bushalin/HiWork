using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiWork.Models.Common;
using HiWork.Models.Product;
using HiWork.Models.SP_User;

namespace HiWork.Models.Order
{
    public class Order : AuditableEntity<int>
    {
        public int OrderAmount { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
