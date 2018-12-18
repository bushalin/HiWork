using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiWork.Controllers.Company
{
    public class CompanyViewController : Controller
    {
        // GET: CompanyView
        public ActionResult CompanyInformations()
        {
            return View();
        }
    }
}