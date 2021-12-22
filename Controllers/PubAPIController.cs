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
    public class PubAPIController : ApiController
    {
            private Library_ManagementEntities1 entobj;
            public PubAPIController()
            {
                this.entobj = new Library_ManagementEntities1();
            }
            [HttpGet]
            public IHttpActionResult GetPublishers()
                {
            List<D_Publisher> publishers = new List<D_Publisher>();
            var records = from r in this.entobj.Publishers  select r;
            foreach (var item in records)
            {
                D_Publisher Pubobj = new D_Publisher()
                {
                    PublisherId = item.PublisherId,
                    PublisherName = item.PublisherName,
                    NoofBooksPublished = item.NoofBooksPublished,
                    City = item.City,
                    ContactInfo = item.ContactInfo
                    
                };
                publishers.Add(Pubobj);
            }
            return Ok(publishers);
        }
            public IHttpActionResult GetPublisher(int id)
            {

            var record = this.entobj.Publishers.SingleOrDefault(rec => rec.PublisherId == id);
            if (record != null)
            {
                D_Publisher Pubobj = new D_Publisher()
                {
                    PublisherId = record.PublisherId,
                    PublisherName = record.PublisherName,
                    NoofBooksPublished = record.NoofBooksPublished,
                    City = record.City,
                    ContactInfo = record.ContactInfo

                };

                return Ok(Pubobj);
            }
            else
            {
                var pub = new Publisher();
                pub.PublisherId = id;
                pub.PublisherName = "record not found";
                return Ok(pub);
            }
                
            }

            [HttpPost]
            public IHttpActionResult PostPublisher(Publisher pubobj)
            {
                this.entobj.Publishers.Add(pubobj);
                this.entobj.SaveChanges();
                return Ok("Record Added Successfully");
            }

            [HttpPut]
            public IHttpActionResult UpdatePublisher(Publisher pubobj)
            {
                var publisher = this.entobj.Publishers.SingleOrDefault(rec => rec.PublisherId == pubobj.PublisherId);
                publisher.PublisherName = pubobj.PublisherName;
                publisher.NoofBooksPublished = pubobj.NoofBooksPublished;
                publisher.City = pubobj.City;
                publisher.ContactInfo = pubobj.ContactInfo;
                this.entobj.SaveChanges();
                return Ok("Record Updated Successfully");
            }
            [HttpDelete]
            public IHttpActionResult DeletePublisher(int id)
            {
                var publisher = this.entobj.Publishers.SingleOrDefault(rec => rec.PublisherId == id);
                this.entobj.Publishers.Remove(publisher);
                this.entobj.SaveChanges();
                return Ok("Record Deleted Successfully");
            }
        }
}
