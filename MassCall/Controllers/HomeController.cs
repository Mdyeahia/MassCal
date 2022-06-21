using MassCall.Models;
using MassCall.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MassCall.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult TotalSummery()
        {
            SummeryViewModel model = new SummeryViewModel();
            ApplicationDbContext context = new ApplicationDbContext();
            var today = DateTime.Today;
            var min = new DateTime(today.Year, today.Month, 1); // first of this month
            var max = min.AddMonths(1); // first of last month

            var raw = context.Database.SqlQuery<SummeryViewModel>("select  m.Name, sum(e.Paid) as paid,p.MonthCost, max(e.EntryDate) as lastEntry, " +
                "case when(p.MonthCost - sum(e.Paid)) = 0 then 'No Due Remain'" +
                "when(p.MonthCost - sum(e.Paid)) > 0 Then m.Name + '  has to pay tk ' + cast((p.MonthCost - sum(e.Paid)) as varchar)" +
                "when(p.MonthCost - sum(e.Paid)) < 0 Then m.Name + '  will get tk ' + cast((p.MonthCost - sum(e.Paid)) as varchar) end as Note " +
                "from [dbo].[MonthlyEntries] e " +
                "join [dbo].[MonthPays] p on p.Memberid = e.Memberid " +
                "join [dbo].[Members] m on m.id = e.Memberid " +
                "where e.EntryDate between  DATEADD(DAY, 1, EOMONTH(GETDATE(), -1)) AND DATEADD(DAY, 1, EOMONTH(GETDATE()))" +
                "group by m.Name, p.MonthCost").ToList();

            model.summeryViewModels = raw;

            //var ppp = from m in context.members
            //          join e in context.monthlyEntries on m.id equals e.Memberid
            //          join p in context.monthPays on m.id equals p.Memberid
            //          where e.EntryDate >= min && e.EntryDate <= max
            //          select new
            //          {
            //              m.Name,
            //              e.Paid,
            //              Note = (
            //              (p.MonthCost - e.Paid) == 0 ? "No Due Remain" :
            //              (p.MonthCost - e.Paid) > 0 ? m.Name + "has to pay tk " + (p.MonthCost - e.Paid) :
            //              (p.MonthCost - e.Paid) < 0 ? m.Name + " will get tk " + (p.MonthCost - e.Paid) : "Not Yet Paid"

            //              ),
            //              e.EntryDate,
            //          };
            return PartialView(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}