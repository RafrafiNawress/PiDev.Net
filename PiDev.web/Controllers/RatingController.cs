using PiDev.Domain.Entity;
using PiDev.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Controllers
{
    public class RatingController : Controller
    {

        RatingService ES = new RatingService();
        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public void Rate(int id)
        {

            rating Rating = new rating
            {
                rate = Convert.ToInt32(Convert.ToDouble(Request.QueryString["rate"])*2),
                employee_id = id,
                created_at = DateTime.Now
            };
            ES.Add(Rating);
            ES.Commit();
        }


        public ActionResult CreateRating()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateRating(rating rating)
        {
            try
            {
                ES.Add(rating);
                ES.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                rating rating=ES.GetById(id);
                ES.Delete(rating);
                ES.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}