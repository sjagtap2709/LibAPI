using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_API.Models
{
    public class D_Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public Nullable<int> NoofBooksPublished { get; set; }
        public string City { get; set; }
        public Nullable<long> ContactInfo { get; set; }
    }
}