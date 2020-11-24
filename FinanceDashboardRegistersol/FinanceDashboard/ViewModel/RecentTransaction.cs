using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinanceDashboard.ViewModel
{
    public class RecentTransaction
    {
        [Key]
        public int OrderID { get; set; }//OrderDetails.cs
        public string ProductName { get; set; }//Product.cs
        public System.DateTime OrderDate { get; set; }//Order.cs
        public double AmountPaid { get; set; }
    }
}