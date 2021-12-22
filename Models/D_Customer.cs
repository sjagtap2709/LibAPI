using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_API.Models
{
    public class D_Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Nullable<System.DateTime> CustomerDOB { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
    }
}