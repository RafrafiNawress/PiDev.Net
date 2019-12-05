using PiDev.Domain.Entities;
using PiDev.Service;
using PiDev.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PiDev.web.Controllers
{
    public class ClaimController : Controller
    {
        IClaimService claimService = null;
        public ClaimController()
        {
            claimService = new ClaimService();
        }
        // GET: Claim
        public ActionResult Index()
        {
            // return View(claimService.GetMany());
            var claims = new List<claimVM>();
            var list = claimService.GetMany().ToList();
            foreach (var item in list)
            {
                claims.Add(new claimVM()
                {
                    claimdate = item.claimdate,
                    subject = item.subject,
                    message = item.message,
                });
                
            }
            return View(claims);
        }

        // GET: Claim/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Claim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Claim/Create
        [HttpPost]
        public ActionResult Create(claimVM cvm)
        {
            claim claimdomain = new claim()
            {
                claimdate = DateTime.Now,
                subject = cvm.subject,
                message = cvm.message,
            };
            claimService.Add(claimdomain);
            claimService.Commit();
            
                return View();
            
        }

        // GET: Claim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Claim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Claim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Claim/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            claim c = claimService.GetById(id);
            claimService.Delete(c);
            claimService.Commit();


            return RedirectToAction("Index");
        }
    }
}
