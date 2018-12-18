using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HiWork.Services.CompanyInformation;
using HiWork.Services.Order;

namespace HiWork.Controllers.Company
{
    [RoutePrefix("Api/Company")]
    public class CompanyController : ApiController
    {
        private readonly ICompanyInformationServices _services;
        public CompanyController()
        {
            _services = new CompanyInformationServices();
        }


        [Route("GetCompanyDetailsById/{companyId:int}")]
        [HttpGet]
        public IHttpActionResult GetCompanyDetailsById(int companyId)
        {
            return Ok(_services.GetCompanyDetailsById(companyId));
        }
    }
}
