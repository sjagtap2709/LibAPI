using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_API.Models
{
    public class D_Auther
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public Nullable<int> NoofBooksWritten { get; set; }
        public Nullable<long> AuthorContact { get; set; }
        public string AuthorMailId { get; set; }
        public string AuthorCity { get; set; }
    }
}