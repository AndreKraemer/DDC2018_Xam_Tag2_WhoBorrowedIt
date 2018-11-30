using System;

namespace WhoBorrowedIt.Models
{
    public class LentItem   
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string Person { get; set; }
        public DateTime LentDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}