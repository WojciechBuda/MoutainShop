using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoutainShop.Domain.Models
{
    public class Backpack : Product //dziedziczenie
    {
        public string Brand { get; set; }
        public string Volume { get; set; }
    }
}
