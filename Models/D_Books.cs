using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_API.Models
{
    public class D_Books
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public Nullable<int> BookAuthorId { get; set; }
        public Nullable<int> BookPublisherId { get; set; }
        public Nullable<int> BookPrice { get; set; }
        public string BookCatagory { get; set; }
        public Nullable<int> NoofCopies { get; set; }
    }
}