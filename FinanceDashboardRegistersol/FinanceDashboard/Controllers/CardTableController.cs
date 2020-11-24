using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FinanceDashboard.Models;
using FinanceDashboard.ViewModel;
using System.Collections;

namespace FinanceDashboard.Controllers
{
    public class CardTableController : ApiController
    {
        private FinanceEntities db = new FinanceEntities();

        // GET: api/CardTable
        public IQueryable<CardTable> GetCardTables()
        {
            return db.CardTables;
        }

        /*#region carddetails
        // GET: api/CardTable/Name
        [ResponseType(typeof(CardTable))]
        //[Route("CardTable/{id}")]
        public IHttpActionResult GetCardTable([FromUri] long? id)
        {
            CardTable cardTable = db.CardTables.Find(id);
            if (cardTable == null)
            {
                return NotFound();
            }

            return Ok(cardTable);
        }
        #endregion
        */
        [Route("api/CardTable/{username}")]
        public HttpResponseMessage Get(string username)
        {
            var card = (from e in db.CardTables
                       where e.Name == username
                       select e
                     ).ToList();
            return this.Request.CreateResponse(HttpStatusCode.OK, card);


        }


        #region Creditdetails
        //[ResponseType(typeof(Creditdetails))]
        [Route("api/CardTable/GetCredit")]
        public IEnumerable GetCreditdetails(string username)
        {
            List<Creditdetails> creditlist = new List<Creditdetails>();
            var cl = (from c in db.CardTables
                      join o in db.Orders on
                      c.CardNumber equals o.CardNumber
                      join od in db.OrderDetails on
                      o.OrderID equals od.OrderID
                      where c.Name==username
                      select new { c.CardNumber, c.TotalCredit, creditused = (od.TotalAmount + od.ProcessingFee), Remainingcredit = c.TotalCredit - (od.TotalAmount + od.ProcessingFee) }
                    ).ToList();
            /*Creditdetails objcl = new Creditdetails();
            foreach (var item in cl)
            {
                
                objcl.CardNumber = item.CardNumber;
                objcl.TotalCredit = item.TotalCredit;
                objcl.creditused = item.creditused;
                objcl.Remainingcredit = item.Remainingcredit;
                creditlist.Add(objcl);

            }*/
            return cl;

        }
        #endregion

        #region products_purchased

        //[ResponseType(typeof(Productpurchase))]
        [Route("api/CardTable/GetProducts")]
        public IEnumerable GetProductspurchased(string username)
        {
            List<Productpurchase> productslist = new List<Productpurchase>();
            var pl = (from p in db.Products
                      join od in db.OrderDetails on
                      p.ProductID equals od.ProductID
                      join o in db.Orders on od.OrderID
                      equals o.OrderID join c in db.CardTables on o.CardNumber equals c.CardNumber
                      where c.Name == username
                      select new { od.OrderID,p.ProductName, p.CostPerUnit, AmountPaid=od.TotalAmount+od.ProcessingFee, Balance = c.TotalCredit-(od.TotalAmount + od.ProcessingFee)}

                    ).ToList();
            /*foreach (var item in pl)
            {
                Productpurchase objpl = new Productpurchase();
                objpl.OrderID = item.OrderID;
                objpl.ProductName=item.ProductName;
                objpl.CostPerUnit = item.CostPerUnit;
                objpl.AmountPaid = item.AmountPaid;
                objpl.Balance = item.Balance;

                productslist.Add(objpl);

            }*/
            return pl;
        }

        #endregion


        #region recent_transactions
        //[ResponseType(typeof(RecentTransaction))]
        [Route("api/CardTable/GetTransactions")]
        public IEnumerable GetRecenttransactions(string username)
        {
            List<RecentTransaction> transactionlist = new List<RecentTransaction>();
            var tl = (from p in db.Products
                      join od in db.OrderDetails on
                      p.ProductID equals od.ProductID
                      join o in db.Orders on od.OrderID
                      equals o.OrderID join c in db.CardTables on o.CardNumber equals c.CardNumber
                       where c.Name == username
                      select new { od.OrderID, p.ProductName, o.OrderDate, AmountPaid = od.TotalAmount + od.ProcessingFee }

                    ).ToList();
            /*foreach (var item in tl)
            {
                RecentTransaction objtl = new RecentTransaction();
                objtl.OrderID = item.OrderID;
                objtl.ProductName = item.ProductName;
                objtl.OrderDate = item.OrderDate;
                objtl.AmountPaid = item.AmountPaid;

                transactionlist.Add(objtl);

            }*/
            return tl;
        }
        #endregion


    }
}