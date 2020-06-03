using System;

namespace CanteenMenuInterface.Models
{
    public class OrderModelJoined
    {
        public int OrderKey { get; set; }
        public string MenuName { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrderStatusName { get; set; }
        public string Comment { get; set; }
    }
}
