using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinanceDashboard.ViewModel
{
    public class Creditdetails
    {
        [Key]
        public long CardNumber { get; set; }
        public int TotalCredit { get; set; }
        public double creditused { get; set; }
        public double Remainingcredit { get; set; }


    }
}