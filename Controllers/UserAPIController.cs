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
    public class UserAPIController : ApiController
    {

        private Library_ManagementEntities1 entobj;
        public UserAPIController()
        {
            this.entobj = new Library_ManagementEntities1();
        }

        public IHttpActionResult GetBooksForUSer()
        {
            List<UserTransaction> userTransactions = new List<UserTransaction>();
            var books = from record in entobj.Books  select record;

            foreach (var item in books)
            {
       
                var pubrec = (from record in entobj.Publishers where record.PublisherId == item.BookPublisherId select record).SingleOrDefault();
                var authrec = (from record in entobj.Authors where record.AuthorId == item.BookAuthorId select record).SingleOrDefault();
                UserTransaction transaction = new UserTransaction()
                {
                    BookId = (int)item.BookId,
                    BookName = item.BookName,
                    BookPrice = (int)item.BookPrice,
                    BookCatagory = item.BookCatagory,
                    PubLisherName = pubrec.PublisherName,
                    AuthorName = authrec.AuthorName
                };
                userTransactions.Add(transaction);
            }
            return Ok(userTransactions);
        }
        [HttpGet]
        public IHttpActionResult GetTransactionForUser(int id)
        {
            List<UserTransaction> userTransactions = new List<UserTransaction>();
            var trans = from record in entobj.Book_Transaction where record.CustomerID == id  select record;

            foreach (var item in trans)
            {
                var bkrecord = (from record in entobj.Books where record.BookId == item.BookId select record).SingleOrDefault();
                var pubrec=(from record in entobj.Publishers where record.PublisherId==bkrecord.BookPublisherId select record).SingleOrDefault();
                var authrec=(from record in entobj.Authors where record.AuthorId==bkrecord.BookAuthorId select record).SingleOrDefault();
                UserTransaction transaction = new UserTransaction()
                {
                    BookId = (int)item.BookId,
                    TransactionStatus = item.TransactionStatus,
                    BookPrice = (int)bkrecord.BookPrice,
                    BookCatagory = bkrecord.BookCatagory,
                    BookName = bkrecord.BookName,
                    BookIssueDate = (DateTime)item.BookIssueDate,
                    TransactionID = item.TransactionID,
                    PubLisherName = pubrec.PublisherName,
                    AuthorName =authrec.AuthorName 
                };
                if (item.TransactionStatus == "Submitted")
                {

                    transaction.BookSubmitDate = (DateTime)item.BookSubmitDate;
                }
                else
                {
                    transaction.BookSubmitDate = null;
                }
                userTransactions.Add(transaction);
            }
            userTransactions.Reverse();
            return Ok(userTransactions);
        }

        }
}
