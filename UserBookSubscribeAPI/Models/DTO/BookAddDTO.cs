using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBookSubscribeAPI.Entities.DTO
{
    public class BookAddDTO
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public double PurchasePrice { get; set; }
    }
}
