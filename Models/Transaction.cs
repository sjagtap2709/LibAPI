using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_API.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<System.DateTime> BookIssueDate { get; set; }
        public Nullable<System.DateTime> BookSubmitDate { get; set; }
        public string TransactionStatus { get; set; }
    }
}