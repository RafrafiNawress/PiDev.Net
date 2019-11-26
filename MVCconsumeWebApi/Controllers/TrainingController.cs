using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCconsumeWebApi.Controllers
{

    public class TrainingController : ApiController
    {
        public Action Affichage
        {
            get
            {

                {
                    HttpClient Client = new HttpClient();
                    Client.BaseAddress = new Uri("http://localhost:522138");

                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json);
    
    }
            }
        }
    }
}
