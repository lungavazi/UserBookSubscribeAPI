using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserBookSubscribeAPI.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public double PurchasePrice { get; set; }
    }
}
