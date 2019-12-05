using Newtonsoft.Json;
using PiDev.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PiDev.web.Controllers
{
    public class EmployeController : Controller
    {
        // GET: Employe
        public ActionResult Index()
        {
            var url = "http://localhost:9080/pidev-web/api/Employee";
            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            string result;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            List<employee> l = JsonConvert.DeserializeObject<List<employee>>(result, new MyDateTimeConverter());
            ViewBag.Result = l;
           // List<employee> l = new JavaScriptSerializer().Deserialize<List<employee>>(result);

        
            return View();
        }
        public class MyDateTimeConverter : Newtonsoft.Json.JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(DateTime);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var t = long.Parse((string)reader.Value);
                return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(t);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
        public string Index1(int id)
        {
            var url = "http://localhost:9080/pidev-web/api/Employee";
            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            string result;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public ActionResult activate(int id)
        {
           
            


            var url = "http://localhost:9080/pidev-web/api/Employee/activate/"+id;
            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "POST";

            using (Stream webStream = webrequest.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write("");
            }
            return RedirectToAction("Index");
        }


    }
}
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View("Create");
        //}
        //[HttpPost]
        //public ActionResult Create(employee evn)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:52138");
        //    client.PostAsJsonAsync<employee>("api/Employee", evn).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
        //    return RedirectToAction("Index");

        //} } }