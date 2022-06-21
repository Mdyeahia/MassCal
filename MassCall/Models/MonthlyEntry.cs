using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassCall.Models
{
    public class MonthlyEntry
    {
        public int id { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Paid { get; set; }
        public int Memberid { get; set; }
        public virtual Member Member { get; set; }
    }
}