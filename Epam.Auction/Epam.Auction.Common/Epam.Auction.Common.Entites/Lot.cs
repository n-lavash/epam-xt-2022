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
        public int id { get; private set; }
        public string name { get; private set; }
        public DateTime dateAdded { get; private set; }
        public double price { get; private set; }
        public string description { get; private set; }

        public Lot(int id, string name, DateTime dateAdded, double price, string description)
        {
            this.id = id;
            this.name = name;
            this.dateAdded = dateAdded;
            this.price = price;
            this.description = description;
        }

        public override string? ToString() => JsonConvert.SerializeObject(this);
    }
}
