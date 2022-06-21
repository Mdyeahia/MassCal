using MassCall.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassCall.ViewModels
{
    public class SummeryViewModel
    {
        //Name,Paid,MonthCost,Note,EntryDate
        public string Name { get; set; }
        public decimal Paid { get; set; }
        public decimal MonthCost { get; set; }
        public string Note { get; set; }
        public DateTime lastEntry { get; set; }

        public List<SummeryViewModel> summeryViewModels { get; set; }

    }

}