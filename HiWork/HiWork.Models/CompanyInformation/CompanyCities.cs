using System.ComponentModel.DataAnnotations.Schema;
using HiWork.Models.Common;

namespace HiWork.Models.CompanyInformation
{
    public class CompanyCities : Entity<int>
    {
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual CompanyInformation.Company Company { get; set; }

        public int? CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
