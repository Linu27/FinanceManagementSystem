using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjCardDashboardWebAPI.ViewModels
{
    public class ChangePassword
    {
        public string Email { get; set; }//consumertable.cs
        public Nullable<int> OTP { get; set; }
        public string Password { get; set; }//consumertable.cs
        public string Confirmpassword { get; set; }
    }
}