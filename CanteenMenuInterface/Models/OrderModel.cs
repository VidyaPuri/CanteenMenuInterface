
namespace CanteenMenuInterface.Models
{
    public class OrderModel
    {
        public int OrderKey { get; set; }
        public int DateMenuKey { get; set; }
        public int UserKey { get; set; }
        public int OrderStatusKey { get; set; }
        public string Comment { get; set; }
    }
}
