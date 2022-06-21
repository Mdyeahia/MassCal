using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MassCall.Models
{
    public class MonthPay
    {
        public int id { get; set; }
        public int Month { get; set; }
        public decimal MonthCost { get; set; }
        public int Memberid { get; set; }
        public virtual Member Member { get; set; }
       
    }
}