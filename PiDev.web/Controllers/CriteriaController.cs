
using PiDev.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Controllers
{
    public class CriteriaController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("pidev-web/rest/criteria").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<criteria>>().Result;
            }
            else
            {
                ViewBag.result = "error";

            }
            return View();
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/criteria/" + id).Result;
            criteria project = new criteria();
            if (response.IsSuccessStatusCode)
            {

                project = response.Content.ReadAsAsync<criteria>().Result;

            }
            else
            {
                ViewBag.project = "erreur";
            }

            return View(project);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            criteria criteria = new criteria();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //houni essta3mlt service GetProjectById 
            HttpResponseMessage response = client.GetAsync("rest/criteria/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                criteria = response.Content.ReadAsAsync<criteria>().Result;
                UpdateModel(criteria, collection);

                // TODO: Add insert logic here

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
                client2.PutAsJsonAsync<criteria>("rest/criteria", criteria).ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }


    }
}
