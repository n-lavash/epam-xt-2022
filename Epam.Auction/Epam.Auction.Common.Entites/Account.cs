using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.Common.Entites
{
    public class Account : User
    {
        public Account(int id, DateTime birthdate, 
            string name, string email, 
            string login, string password) 
            : base(id, birthdate, name, email)
        {
            Id = id;
            Role = "user";
            Birthdate = birthdate;
            Name = name;
            RegDate = DateTime.Now;
            Email = email;
            Login = login;
            Password = password;
        }

        public Account(int id, string role, DateTime birthdate,
            string name, string email,
            string login, string password, DateTime regDate, IEnumerable<Lot> lots)
            : base(id, birthdate, name, regDate, email)
        {
            Id = id;
            Role = role;
            Birthdate = birthdate;
            Name = name;
            RegDate = regDate;
            Email = email;
            Login = login;
            Password = password;
            Lots = lots;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public IEnumerable<Lot> Lots { get; set; }


        public override string? ToString()
        {

            var result = new StringBuilder();
            result.Append("\nUser number: ").Append(Convert.ToInt32(Id)).
                Append("\n\tName: ").Append(Name).
                Append("\n\tRole: ").Append(Role).
                Append("\n\tLogin: ").Append(Login).
                Append("\n\tEmail: ").Append(Email).
                Append("\n\tBirth date: ").Append(Birthdate).
                Append("\n\tRegistration date: ").Append(RegDate).
                Append("\n\tLots: ");

            foreach (var item in Lots)
            {
                result.Append("\n\t\t").Append(item);
            }

            return result.ToString();
        }
    }
}
