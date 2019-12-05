using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiDev.web.Models
{
    public class claimVM
    {
        public int id { get; set; }

        public DateTime? claimdate { get; set; }

        public String subject { get; set; }

        public String message { get; set; }




    }
}