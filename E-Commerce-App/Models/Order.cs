namespace E_Commerce_App.Models
{
    public class Order
    {
        //public int ID { get; set; }

        public int ID { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string StreetAddress { get; set; }

        public string PostalCode { get; set; }

        public string? Status { get; set; }

        public DateTime OrderDate { get; set; }

        public string SessionID { get; set; }

        public double TotalPrice { get; set; }

        public List<ShoppingCartItem> Items { get; set; }



        //public int TotalPrice { get; set; }

        //public List<Product> Products { get; set; }

        //public bool IsCompleted { get; set; }

    }
}
