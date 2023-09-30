namespace E_Commerce_App.Models
{
    public class ShoppingCartItem
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string ProductUrl { get; set; }

        public int Quantity { get; set; }

        public string? DepartmentName { get; set; } // we should change it 

        public double? ProductDiscount { get; set; }


    }
}
