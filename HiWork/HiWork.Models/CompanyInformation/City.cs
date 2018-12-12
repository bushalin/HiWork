using System.ComponentModel.DataAnnotations.Schema;
using HiWork.Models.Common;

namespace HiWork.Models.CompanyInformation
{
    public class City : Entity<int>
    {
        public string CityName { get; set; }

        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
