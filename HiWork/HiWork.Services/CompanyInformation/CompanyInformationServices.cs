using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HiWork.Common;
using HiWork.Models;
using HiWork.Models.CompanyInformation;

namespace HiWork.Services.CompanyInformation
{
    public class CompanyInformationServices : ICompanyInformationServices
    {
        private readonly HiWorkDbContext _context;
        private readonly IEntityService<Company> _services;
        public CompanyInformationServices()
        {
            _context = new HiWorkDbContext();
            _services = new EntityService<Company>(_context);
        }

        //For checking if the company name already exists?
        private bool IsCompanyNameFound(string companyName)
        {
            var result = _context.Company.Where(u => u.CompanyName == companyName).Select(x => x.Id).FirstOrDefault();

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        //Retrieving all the company information using generic service
        public JsonResult GetAllCompanyInfo()
        {
            var result = _services.GetAll().ToList();

            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetCompanyDetailsById(int companyId)
        {
            var result = _context.Company.Where(c => c.Id == companyId)
                .Join(_context.CompanyCities,
                    c => c.Id,
                    cc => cc.CompanyId,
                    (c, cc) => new {Company = c, CompanyCities = cc})
                .Select(x => new
                {
                    x = x.Company,

                    CompanyCities = _context.CompanyCities.Where(ccities => ccities.CompanyId == x.Company.Id)
                        .Join(_context.City,
                            ccities => ccities.CityId,
                            city => city.Id,
                            (ccities, city) => new { CompanyCity = ccities, City = city })
                        .Select(k => new
                        {
                            k.City.CityName,
                            k.City.Id,
                            k.City.Country.CountryName
                        }).ToList()
                    //Industry = _context.CompanyIndustries.Where(ci => ci.CompanyId == x.Company.IndustryId)
                    //    .Join(_context.Industry,
                    //        ci => ci.IndustryId,
                    //        i => i.Id,
                    //        (ci, i) => new {CompanyIndustries = ci, i = Industry})
                    //    .Select(z = new
                    //    {
                    //        z = z
                    //    }).ToList()
                }).FirstOrDefault();
            

            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        //Save company information using generic services
        public JsonResult SaveCompany(Company obj)
        {
            var message = "";

            if (obj.EMail == null || obj.CompanyName == null)
            {
                message = "You did not provide email or password!";
                Generator.IsReport = "Warning";
            }
            else if (IsCompanyNameFound(obj.CompanyName))
            {
                message = "Company name exists ! Please choose a different company name.";
                Generator.IsReport = "Warning";
            }
            else
            {
                try
                {
                    _services.Save(obj);
                    _services.SaveChanges();
                    message = "Company saved successfully !";
                    Generator.IsReport = "Ok";
                }
                catch (Exception ex)
                {
                    //message = "Something went wrong ! Please contact system administrator.";
                    message = ex.Message;
                    Generator.IsReport = "NotOk";
                }
            }
            return new JsonResult
            {
                Data = new
                {
                    Message = message,
                    Generator.IsReport
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }

    public interface ICompanyInformationServices
    {
        JsonResult GetAllCompanyInfo();
        JsonResult GetCompanyDetailsById(int companyId);
        JsonResult SaveCompany(Company obj);
    }
}
