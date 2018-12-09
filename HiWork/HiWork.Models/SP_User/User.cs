using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HiWork.Models.Common;

namespace HiWork.Models.SP_User
{
    public class User : Entity<int>
    {
        [MaxLength(20)]
        public string Username { get; set; }
        public string Password { get; set; }
        [MaxLength(75)]
        public string FirstName { get; set; }
        [MaxLength(75)]
        public string LastName { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Gender { get; set; }
        [MaxLength(50)]
        public string Mobile { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
