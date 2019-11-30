using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PiDev.Service;
using PiDev.Data;

namespace PiDev.web.Controllers
{
    public class Mission2Controller : Controller
    {
        private MissionService cs = new MissionService();
        private Context db = new Context();

        //GET: Mission Project
        public ActionResult MissionByProject()
        {
            var mission = db.bills.FirstOrDefault();


            return View(cs.GetMany().ToList());
        }


        // GET: Bill/Create
        public ActionResult CreateBill()
        {
            return View();
        }
    }
}