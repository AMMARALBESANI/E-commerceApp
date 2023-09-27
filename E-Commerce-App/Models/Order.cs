namespace E_Commerce_App.Models
{
    public class Order
    {
        public int ID { get; set; }

        public int TotalPrice { get; set; }

        public List<Product> Products { get; set; }

        public bool IsCompleted { get; set; }

    }
}
