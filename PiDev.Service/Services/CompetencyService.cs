using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Service.Services
{
    public class CompetencyService
    {
        public string GetJobs()
        {
            var url = "http://localhost:9080/pidev-web/rest/jobs";
            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            string result;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public string GetJobCompetencies(int id)
        {
            var url = "http://localhost:9080/pidev-web/rest/jobs/" + id;
            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            string result;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
