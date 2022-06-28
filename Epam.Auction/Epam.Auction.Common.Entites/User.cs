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
        public User(int idUser, string name, DateTime birthdate)
        {
            this.idUser = idUser;
            this.name = name;
            this.birthdate = birthdate;
        }

        public int idUser { get; set; }
        public int idAccount { get; set; }
        public string login { get; private set; }
        public string password { get; private set; }
        public string role { get; private set; }
        public DateTime birthdate { get; private set; }
        public string name { get; private set; }
        public DateTime regDate { get;}
        public string email { get; private set; }

        public override string? ToString() => JsonConvert.SerializeObject(this);
    }
}
