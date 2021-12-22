using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library_Management_API.Models;
using System.Web.Http.Cors;
namespace Library_Management_API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TransAPIController : ApiController
    {
       

            private Library_ManagementEntities1 entobj;
        private object orderByDescending;

        public TransAPIController()
            {
                this.entobj = new Library_ManagementEntities1();
            }
            [HttpGet]
            public IHttpActionResult GetTransactions()
            {
            List<Transaction> transactions = new List<Transaction>();
            var records =from r in this.entobj.Book_Transaction orderby r.TransactionID descending select r   ;
            foreach (var item in records)
            {
                Transaction tranobj = new Transaction()
                {
                    TransactionID = item.TransactionID,
                    CustomerID = item.CustomerID,
                    BookId = item.BookId,
                    BookIssueDate = item.BookIssueDate,
                    BookSubmitDate = item.BookSubmitDate,
                    TransactionStatus = item.TransactionStatus
                };
                transactions.Add(tranobj);
            }
            return Ok(transactions);
            }
        public IHttpActionResult GetTransaction(int id)
        {
            List<Transaction> transactions = new List<Transaction>();
            var cust = from r in this.entobj.Book_Transaction where r.CustomerID == id && r.TransactionStatus == "Issued" select r;
            if (cust != null)
            {
                foreach (var item in cust)
                {
                    Transaction tranobj = new Transaction()
                    {
                        TransactionID = item.TransactionID,
                        CustomerID = item.CustomerID,
                        BookId = item.BookId,
                        BookIssueDate = item.BookIssueDate,
                        BookSubmitDate = item.BookSubmitDate,
                        TransactionStatus = item.TransactionStatus
                    };
                    transactions.Add(tranobj);
                }
                return Ok(transactions);
            }

            else
            {
                var tranobj = new Book_Transaction();
                tranobj.TransactionID = id;
                tranobj.TransactionStatus = "record not found";
                return Ok(tranobj);
            }
        }
            [HttpPost]
            public IHttpActionResult IssueBook(Book_Transaction transobj)
            {
                
                this.entobj.Book_Transaction.Add(transobj);
                var record = this.entobj.Books.SingleOrDefault(rec => rec.BookId == transobj.BookId);
                record.NoofCopies= record.NoofCopies-1;
                this.entobj.SaveChanges();
                return Ok("Book Issued Successfully");
            }

            [HttpPut]
            public IHttpActionResult SubmitBook(Book_Transaction transobj)
            {
                var transaction = this.entobj.Book_Transaction.SingleOrDefault(rec => rec.TransactionID == transobj.TransactionID);
                var record = this.entobj.Books.SingleOrDefault(rec => rec.BookId == transobj.BookId);
                record.NoofCopies = record.NoofCopies + 1;
                transaction.BookSubmitDate = transobj.BookSubmitDate;
                transaction.TransactionStatus = "Submitted";
                this.entobj.SaveChanges();
                return Ok("Book Submitted Successfully");
            }

          
        }
}
