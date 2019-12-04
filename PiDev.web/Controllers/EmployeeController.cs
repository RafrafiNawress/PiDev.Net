using PiDev.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
        { 
        HttpClient Client = new HttpClient();
        Client.BaseAddress = new Uri("http://localhost:52138");
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = Client.GetAsync("api/Employee").Result;
        if (response.IsSuccessStatusCode) 
          {
                ViewBag.result = response.Content.ReadAsAsync <IEnumerable<(employee>>().Result;
          } else
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
        public ActionResult Create(employee evn)
{
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:52138");
    client.PostAsJsonAsync<employee>("api/Employee", evn).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
    return RedirectToAction("Index"); 

}