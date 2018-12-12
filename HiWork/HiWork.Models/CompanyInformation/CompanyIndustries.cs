using System.ComponentModel.DataAnnotations.Schema;
using HiWork.Models.Common;

namespace HiWork.Models.CompanyInformation
{
    public class CompanyIndustries : Entity<int>
    {
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual CompanyInformation.Company Company { get; set; }

        public int? IndustryId { get; set; }
        [ForeignKey("IndustryId")]
        public virtual Industry Industry { get; set; }
    }
}
