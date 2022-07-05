using MassCall.Models;
using MassCall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassCall.Controllers
{
    public class MonthlyEntryController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult MonthlyEntry()
        {
            MonthPayViewModel model = new MonthPayViewModel();
            ApplicationDbContext context = new ApplicationDbContext();

            model.Allmembers = context.members.ToList();

            return PartialView(model);
        }
        public ActionResult MonthlyEntry(MonthlyEntry model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var newdata = new MonthlyEntry();
            newdata.Memberid = model.Memberid;
            newdata.Paid = model.Paid;
            newdata.EntryDate = DateTime.Now;

            context.monthlyEntries.Add(newdata);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}