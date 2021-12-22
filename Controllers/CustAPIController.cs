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
    public class CustAPIController : ApiController
    {
        private Library_ManagementEntities1 entobj;
        public CustAPIController()
        {
            this.entobj = new Library_ManagementEntities1();
        }
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            List<D_Customer> customers = new List<D_Customer>();
            var records = from r in this.entobj.Customers select r;
            foreach (var item in records)
            {
                D_Customer Custobj = new D_Customer()
                {
                    CustomerId = item.CustomerId,
                    CustomerName = item.CustomerName,
                    CustomerDOB = item.CustomerDOB,
                    CustomerContact = item.CustomerContact,
                    CustomerAddress = item.CustomerAddress,
                    CustomerGender = item.CustomerGender,
                    CustomerEmail = item.CustomerEmail,
                    CustomerPassword = item.CustomerPassword
                };
                customers.Add(Custobj);
            }

            return Ok(customers);

        }
        public IHttpActionResult GetCustomer(int id)
        {
            var record = this.entobj.Customers.SingleOrDefault(rec => rec.CustomerId == id);
            if (record != null)
            {
                D_Customer Custobj = new D_Customer()
                {
                    CustomerId = record.CustomerId,
                    CustomerName = record.CustomerName,
                    CustomerDOB = record.CustomerDOB,
                    CustomerContact = record.CustomerContact,
                    CustomerAddress = record.CustomerAddress,
                    CustomerGender = record.CustomerGender,
                    CustomerEmail = record.CustomerEmail,
                    CustomerPassword = record.CustomerPassword
                };
                return Ok(Custobj);
            }
            else
            {
                var cusObj = new Customer();
                cusObj.CustomerId = id;
                cusObj.CustomerName = "record not found";
                return Ok(cusObj);
            }

        }
        [HttpPost]
        public IHttpActionResult PostCustomer(Customer custobj)
        {
            this.entobj.Customers.Add(custobj);
            this.entobj.SaveChanges();
            return Ok("Record Added Successfully");
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(Customer custobj)
        {
            var customer = this.entobj.Customers.SingleOrDefault(rec => rec.CustomerId == custobj.CustomerId);
            customer.CustomerName = custobj.CustomerName;
            customer.CustomerAddress = custobj.CustomerAddress;
            customer.CustomerContact = custobj.CustomerContact;
            customer.CustomerDOB = custobj.CustomerDOB;
            customer.CustomerGender = custobj.CustomerGender;
            customer.CustomerEmail = custobj.CustomerEmail;
            customer.CustomerPassword = custobj.CustomerPassword;

            this.entobj.SaveChanges();
            return Ok("Record updated Successfully");
        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = this.entobj.Customers.SingleOrDefault(rec => rec.CustomerId == id);
            this.entobj.Customers.Remove(customer);
            this.entobj.SaveChanges();
            return Ok("Record Deleted Successfully");
        }


    }
       
}
