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

        public ActionResult Stats()
        {
            return View();
        }

        public string GetEmployees(int jobId)
        { 
            return _service.GetEmployees(jobId);
        }

        public string GetJobs()
        {
            return _service.GetJobs();
        }

        public string GetJobCompetencies(int id)
        {
            return _service.GetJobCompetencies(id);
        }

        [HttpPost]
        public void AssignJob(int empId, int jobId)
        {
            _service.AssignJob(empId, jobId);
        }

        public string GetCompetenciesOverview()
        {
            return _service.GetCompetenciesOverview();
        }
        public string GetEmployeesByCompetency(string compName)
        {

            return _service.GetEmployeesByCompetency(compName);
        }
    }
}