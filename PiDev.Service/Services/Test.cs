using PiDev.Data;
using PiDev.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Service.Services
{
    public class Test
    {
        public void test()
        {
            var url = "http://localhost:9080/pidev-web/rest/families";
            var webrequest = (HttpWebRequest)WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
            }
            using (Context dbc = new Context())
            {
                jobfamily j = new jobfamily();
                j.description = ".net fam";
                j.name = ".net fam name";
                dbc.jobfamilies.Add(j);
                dbc.SaveChanges();
            }
        }
    }
}
