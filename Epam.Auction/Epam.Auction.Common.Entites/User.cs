using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.Common.Entites
{
    public class User
    {
        public User(int id, DateTime birthdate, string name, string email)
        {
            Id = id;
            Birthdate = birthdate;
            Name = name;
            RegDate = DateTime.Now;
            Email = email;
        }

        public User(int id, DateTime birthdate, string name, DateTime regDate, string email)
        {
            Id = id;
            Birthdate = birthdate;
            Name = name;
            RegDate = regDate;
            Email = email;
        }

        public int Id { get; set; }
        public DateTime Birthdate { get; set; }
        public string Name { get; set; }
        public DateTime RegDate { get; set; }
        public string Email { get; set; }

        public override string? ToString()
        {
            var result = new StringBuilder();
            result.Append("\nUser number: ").Append(Convert.ToInt32(Id)).
                Append("\n\tName: ").Append(Name).
                Append("\n\tEmail: ").Append(Email).
                Append("\n\tBirth date: ").Append(Birthdate).
                Append("\n\tRegistration date: ").Append(RegDate);

            return result.ToString();
        }
    }
}
