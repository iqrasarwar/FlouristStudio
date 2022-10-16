namespace FlouristStudio.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string[] Colors { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }

        public Product(string Name, string Description, int Price, string[] Colors, int Quantity, int Id)
        {
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Colors = Colors;
            this.Quantity = Quantity;
            this.Id = Id;
        }
    }
}
