using System.ComponentModel.DataAnnotations.Schema;
using HiWork.Models.Common;

namespace HiWork.Models.CompanyInformation
{
    public class Industry : Entity<int>
    {
        public string IndustryName { get; set; }

        public int? IndCatId { get; set; }
        [ForeignKey("IndCatId")]
        public virtual IndustryCategory IndustryCategory { get; set; }
    }
}
