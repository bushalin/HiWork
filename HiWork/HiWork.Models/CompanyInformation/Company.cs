using System;
using System.ComponentModel.DataAnnotations.Schema;
using HiWork.Models.Common;

namespace HiWork.Models.CompanyInformation
{
    public class Company : Entity<int>
    {
        public string EMail { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonPhone { get; set; }
        public string PostalCode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Website { get; set; }
        public string RepresentativeName { get; set; }
        public string BusinessContent { get; set; }
        public string CompanyIntro { get; set; }
        public string ForeginersRecrDes { get; set; }
        public DateTime DOE { get; set; }
        public double Capital { get; set; }
        public int NoOfEmployees { get; set; }
        public bool ForeginersRecrExperience { get; set; }
        public int ForeginersRecrQty { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

        public int? IndustryId { get; set; }
        [ForeignKey("IndustryId ")]
        public virtual Industry Industry { get; set; }
    }
}
