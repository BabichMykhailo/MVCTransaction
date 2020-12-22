using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionMVC.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<TransactionModel> Transactions { get; set; }
    }
}