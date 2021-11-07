
namespace UserBookSubscribeAPI.Models.DTO
{
    public class BookDTO
    {
        public long BookId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public double PurchasePrice { get; set; }
        public int NumberOfSubscriptions { get; set; }
    }
}
