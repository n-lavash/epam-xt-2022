using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.Common.Entites
{
    public class Lot
    {
        public int Id { get;}
        public string Name { get; set; }
        public DateTime DateAdded { get; }
        public double Price { get; set; }
        public string Description { get; set; }

        public Lot(int id, string name, DateTime dateAdded, double price, string description)
        {
            Id = id;
            Name = name;
            DateAdded = dateAdded;
            Price = price;
            Description = description;
        }

        public Lot(int id, string name, double price, string description)
        {
            Id = id;
            Name = name;
            DateAdded = DateTime.Now;
            Price = price;
            Description = description;
        }

        public override string? ToString()
        {
            var result = new StringBuilder();
            result.Append("\nLot number: ").Append(Id).
                Append("\n\tName: ").Append(Name).
                Append("\n\tDate added: ").Append(DateAdded).
                Append("\n\tPrice: ").Append(Price).
                Append("\n\tDescription: ").Append(Description);

            return result.ToString();
        }
    }
}
