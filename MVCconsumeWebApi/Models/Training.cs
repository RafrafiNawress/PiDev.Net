using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCconsumeWebApi.Models
{
    public class Training
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int duree { get; set; }
        public Boolean status { get; set; }
        public int NumberMax { get; set; }
        public string image { get; set; }
        public int? commentaire_id_comment { get; set; }
       




    }
}