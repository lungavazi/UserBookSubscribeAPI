using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserBookSubscribeAPI.Entities
{
    public class Subscribe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime SubscribedDate { get; set; } = DateTime.Now;
    }
}
