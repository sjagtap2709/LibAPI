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

    public class AuthAPIController : ApiController
    {
        private Library_ManagementEntities1 entobj;
        public AuthAPIController()
        {
            this.entobj = new Library_ManagementEntities1();
        }
        [HttpGet]
        public IHttpActionResult GetAuthors()
        {
            List<D_Auther> authors = new List<D_Auther>();
            var records = from r in this.entobj.Authors  select r;
            foreach (var item in records)
            {
                D_Auther AuthObj = new D_Auther()
                {
                    AuthorId = item.AuthorId,
                    AuthorName = item.AuthorName,
                    NoofBooksWritten = item.NoofBooksWritten,
                    AuthorContact = item.AuthorContact,
                    AuthorMailId = item.AuthorMailId,
                    AuthorCity = item.AuthorCity,
                };
                authors.Add(AuthObj);
            
            }
            return Ok(authors);
        }
        public IHttpActionResult GetAuthor(int id)
        {
            var record = this.entobj.Authors.SingleOrDefault(rec => rec.AuthorId == id);
            if (record != null)
            {
                D_Auther AuthObj = new D_Auther()
                {
                    AuthorId = record.AuthorId,
                    AuthorName = record.AuthorName,
                    NoofBooksWritten = record.NoofBooksWritten,
                    AuthorContact = record.AuthorContact,
                    AuthorMailId = record.AuthorMailId,
                    AuthorCity = record.AuthorCity,

                };
                return Ok(AuthObj);
            }
            else
            {
                var authObj = new Author();
                authObj.AuthorId = id;
                authObj.AuthorName = "record not found";
                return Ok(authObj);

            }
                
        }
        [HttpPost]
        public IHttpActionResult PostAuthor(Author authorobj)
        {
            this.entobj.Authors.Add(authorobj);
            this.entobj.SaveChanges();
            return Ok("Record Added Successfully");
        }

        [HttpPut]
        public IHttpActionResult UpdateAuthor(Author authorobj)
        {
            var author = this.entobj.Authors.SingleOrDefault(rec => rec.AuthorId == authorobj.AuthorId);
            author.AuthorName = authorobj.AuthorName;
            author.NoofBooksWritten = authorobj.NoofBooksWritten;
            author.AuthorCity = authorobj.AuthorCity;
            author.AuthorMailId = authorobj.AuthorMailId;
            author.AuthorContact = authorobj.AuthorContact;
            this.entobj.SaveChanges();
            return Ok("Record updated Successfully");
        }
        [HttpDelete]
        public IHttpActionResult DeleteAuthor(int id)
        {
            var author = this.entobj.Authors.SingleOrDefault(rec => rec.AuthorId == id);
            this.entobj.Authors.Remove(author);
            this.entobj.SaveChanges();
            return Ok("Record Deleted Successfully");
        }
    }
}
