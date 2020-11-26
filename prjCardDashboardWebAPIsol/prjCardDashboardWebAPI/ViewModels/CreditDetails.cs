using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace prjCardDashboardWebAPI.ViewModels
{
    public class CreditDetails
    {
        [Key]
        public long CardNumber { get; set; } //CardTable.cs
        public int TotalCredit { get; set; } //CardTable.cs
        public int Creditused { get; set; }
        public Nullable<double> RemainingCredit { get; set; }//CardTable.cs
    }
}