using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_App.Models
{
    public class ShoppingCartItem
    {
        public int ID { get; set; }

        public string username { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public double ProductPrice { get; set; }

        public string? ProductUrl { get; set; }


        public string? DepartmentName { get; set; } // we should change it 

        public double? ProductDiscount { get; set; }

        [ForeignKey("OrderID")]
        public int OrderID { get; set; }

        //public Order Order { get; set; }


    }
}
