using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinanceDashboard.Models;

namespace FinanceDashboard.Controllers
{
    public class RegisterController : ApiController
    {
        FinanceEntities db = new FinanceEntities();
        [HttpGet]
        public IQueryable<ConsumerTable> Get()
        {
            return db.ConsumerTables;
        }
        [HttpPost]
        public IHttpActionResult PostRegister(ConsumerTable consumertable)
        {

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //else 
            if (consumertable != null)
            {

               
                    db.ConsumerTables.Add(consumertable);
                try {
                    
                    db.SaveChanges();
                    return Ok("Registered successfully");
                   
                    }
                catch(Exception)
                {
                    return BadRequest("Enter the data");
                }
                
             }
            else
            {
                return BadRequest("Please enter the data");
            }

        }
    }
}
