namespace Inventory.API.Model
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverPageUrl { get; set; }
        public string FrontMatter { get; set; }
        public int Quantity { get; set; }
    }
}
