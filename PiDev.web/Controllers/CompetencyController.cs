using PiDev.Data;
using PiDev.Domain;
using PiDev.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PiDev.web.Controllers
{
    public class CompetencyController : Controller
    {
        CompetencyService _service = new CompetencyService();
        public ActionResult Index()
        {
            return View();
        }

        public string GetEmployees()
        {
            string result = "[";
            using(Context c = new Context())
            {
                result = new JavaScriptSerializer().Serialize(c.employees.Select(x=> new { id=x.id, firstName= x.firstname, lastName=x.lastname}).ToList());
            }
            return result;
        }

        public string GetJobs()
        {
            return _service.GetJobs();
        }

        public string GetJobCompetencies(int id)
        {
            return _service.GetJobCompetencies(id);
        }
    }
}