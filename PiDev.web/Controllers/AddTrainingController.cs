using PiDev.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Controllers
{
    public class AddTrainingController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("pidev-web/api/Training").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<training>>().Result;
            }
            else
            {
                ViewBag.result = "error";

            }
            return View("TrainingAfichage");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(training evm)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
         Client.PostAsJsonAsync<training>("pidev-web/api/Training", evm).ContinueWith((posttask) => posttask.Result.EnsureSuccessStatusCode());



            return RedirectToAction("Index");



        }
    }
}