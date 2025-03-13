using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoutainShop.ConsoleApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Person(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
