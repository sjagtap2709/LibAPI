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
    public class BookAPIController : ApiController
    {
        
        private Library_ManagementEntities1 entobj;
        public BookAPIController()
        {
            this.entobj = new Library_ManagementEntities1();
        }
        [HttpGet]
        public IHttpActionResult GetBooks()
        {
            List<D_Books> books = new List<D_Books>();
            var records = from r in this.entobj.Books  select r;
            foreach (var item in records)
            {
                D_Books tranobj = new D_Books()
                {
                    BookId = item.BookId,
                    BookName = item.BookName,
                    BookAuthorId = item.BookAuthorId,
                    BookPublisherId = item.BookPublisherId,
                    BookPrice = item.BookPrice,
                    BookCatagory = item.BookCatagory,
                    NoofCopies = item.NoofCopies
                };
                books.Add(tranobj);
            }
            return Ok(books);
        }
        public IHttpActionResult GetBook(int id)
        {
            var record = this.entobj.Books.SingleOrDefault(rec => rec.BookId == id);
            if (record != null)
            {

                D_Books bookobj = new D_Books()
                {
                    BookId = record.BookId,
                    BookName = record.BookName,
                    BookAuthorId = record.BookAuthorId,
                    BookPublisherId = record.BookPublisherId,
                    BookPrice = record.BookPrice,
                    BookCatagory = record.BookCatagory,
                    NoofCopies = record.NoofCopies

                };
                return Ok(bookobj);
            }
            else
            {
                var bokObj = new Book();
                bokObj.BookId = id;
                bokObj.BookName = "record not found";
                return Ok(bokObj);
            }
        }
        [HttpPost]
        public IHttpActionResult PostBook(Book bookobj)
        {
            this.entobj.Books.Add(bookobj);
            this.entobj.SaveChanges();
            return Ok("Record Added Successfully");
        }

        [HttpPut]
        public IHttpActionResult UpdateBook(Book bookobj)
        {
            var book = this.entobj.Books.SingleOrDefault(rec => rec.BookId == bookobj.BookId);
            book.BookName = bookobj.BookName;
            book.BookPrice = bookobj.BookPrice;
            book.BookCatagory = bookobj.BookCatagory;
            book.BookPublisherId = bookobj.BookPublisherId;
            book.BookAuthorId = bookobj.BookAuthorId;
            book.NoofCopies = bookobj.NoofCopies;
            this.entobj.SaveChanges();
            return Ok("Record updated Successfully");
        }
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var book = this.entobj.Books.SingleOrDefault(rec => rec.BookId == id);
            this.entobj.Books.Remove(book);
            this.entobj.SaveChanges();
            return Ok("Record Deleted Successfully");
        }
        
    }
}

