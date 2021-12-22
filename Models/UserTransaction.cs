using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_API.Models
{
    public class UserTransaction
    {
        public int TransactionID { get; set; }
        public int BookId { get; set; }
        public int BookPrice { get; set; }
        public DateTime BookIssueDate { get; set; }
        public Nullable<System.DateTime> BookSubmitDate { get; set; }
        public String AuthorName { get; set; }
        public String BookName { get; set; }
        public String TransactionStatus { get; set; }
        
        public String PubLisherName { get; set; }
        public String BookCatagory { get; set; }
    }
}