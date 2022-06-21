using MassCall.Models;
using MassCall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassCall.Controllers
{
    public class MonthPayController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MonthPay()
        {
            MonthPayViewModel model = new MonthPayViewModel();
            ApplicationDbContext context = new ApplicationDbContext();

            model.Allmembers = context.members.ToList();

            return View(model);
        }
         [HttpPost]
        public ActionResult MonthPay(MonthPay model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var newdata = new MonthPay();
            newdata.Memberid = model.Memberid;
            newdata.Month = model.Month;
            newdata.MonthCost = model.MonthCost;

            context.monthPays.Add(newdata);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}