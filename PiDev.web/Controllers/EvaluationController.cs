using PiDev.Service;
using PiDev.web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;



namespace PiDev.web.Controllers
{
    public class EvaluationController : Controller
    {
        EvaluationService ES = new EvaluationService();
        RatingService RS = new RatingService();

        // GET: Employee
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("pidev-web/rest/evaluation").Result;
            var rates = from rate in RS.GetMany()
                        group rate by rate.employee_id into g
                        select new { employeeId = g.Key, Rating = g.Average(r => r.rate)/2 };
            var dict = rates.ToDictionary(t => t.employeeId, t => t.Rating);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.rates = dict;
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<evaluationsheet>>().Result;

            }
            else
            {
                ViewBag.result = "error";

            }
            return View();
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<ActionResult> Create(evaluationsheet evm)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            var obj = new { score = evm.Score, typeevaluation = evm.typeevaluation, date = ((DateTime)evm.date).ToString("yyyy/MM/dd") };
            HttpResponseMessage response = Client.PostAsJsonAsync("pidev-web/rest/evaluation", obj).Result;
            if (response.IsSuccessStatusCode)
            {

                ViewBag.success = "Added with success !";

                var message = new MailMessage();
                message.To.Add(new MailAddress("mohamed.benabedelfattah@esprit.tn")); //replace with valid value
                message.Subject = "Appointment confirmation";
                message.Body = string.Format("Your appointment on " + obj.date + " has been confirmed");
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                ViewBag.result = "Not added ! ";
                return View();
            }

        }


        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/evaluation/" + id).Result;
            evaluationsheet evaluation = new evaluationsheet();
            if (response.IsSuccessStatusCode)
            {

                evaluation = response.Content.ReadAsAsync<evaluationsheet>().Result;

            }
            else
            {
                ViewBag.evaluation = "erreur";
            }

            return View(evaluation);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080");

                // TODO: Add insert logic here
                client.DeleteAsync("pidev-web/rest/evaluation/" + id)
                        .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult deletCritere(int id)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080");

                // TODO: Add insert logic here
                client.DeleteAsync("pidev-web/rest/criteria/" + id)
                        .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("detail", new { id = id });
            }
        }

        





        public ActionResult detail(int id, FormCollection collection)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("rest/evaluation/" + id).Result;
            evaluationsheet evaluation = new evaluationsheet();
            if (response.IsSuccessStatusCode)
            {

                evaluation = response.Content.ReadAsAsync<evaluationsheet>().Result;

            }
            else
            {
                ViewBag.evaluation = "erreur";
            }

            return View(evaluation);
        }


        public ActionResult stat()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("pidev-web/rest/evaluation").Result;
            var evaluations = response.Content.ReadAsAsync<IEnumerable<evaluationsheet>>().Result;
            var lineStats = from e in evaluations
                            where e.date != null
                            orderby e.date
                            group e by ((DateTime)e.date).ToString("MMM-yyyy", new CultureInfo("en-US")) into g
                            select new { month = g.Key, score = g.Average(ev => ev.Score) };
            var lineDict = lineStats.ToDictionary(e => e.month, e => e.score);
            ViewBag.lineStatsLabels = String.Join("|", lineDict.Keys.ToList());
            ViewBag.lineStatsValues = String.Join("|", lineDict.Values.ToList());

            var barStats = from e in evaluations
                           where e.employee != null
                           select new { employe = e.employee.firstname + " " + e.employee.lastname, score = e.Score };
            var barDict = barStats.ToDictionary(e => e.employe, e => e.score);
            ViewBag.barStatsLabels = String.Join("|", barDict.Keys.ToList());
            ViewBag.barStatsValues = String.Join("|", barDict.Values.ToList());
            return View();
        }

    }
    
}


