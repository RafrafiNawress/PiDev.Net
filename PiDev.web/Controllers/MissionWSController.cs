using PiDev.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Controllers
{
    public class MissionWSController : Controller
    {
        // GET: MissionWS
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
            HttpResponseMessage response = Client.GetAsync("api/mission/project/1").Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<mission> missions = response.Content.ReadAsAsync<IEnumerable<mission>>().Result;
                ViewBag.Result = missions;
            }
            else
            {
                ViewBag.Result = "error";
            }
            Console.WriteLine("ViewBag.Result  : " + ViewBag.Result);

            return View();
        }


        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/mission/" + id).Result;
            mission mission = new mission();
            if (response.IsSuccessStatusCode)
            {

                mission = response.Content.ReadAsAsync<mission>().Result;

            }
            else
            {
                ViewBag.mission = "erreur";
            }

           return View(mission);
        }

        // POST: mission/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");

                // TODO: Add insert logic here
                client.DeleteAsync("api/mission/" + id)
                        .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}