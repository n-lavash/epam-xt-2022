using Epam.Auction.Common.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.BLL.Interfaces
{
    public interface IAuctionLogic
    {
        public bool AddLot(Lot lot);
        public bool DeleteLot(int id);
        public bool EditLotWithAllParameters(Lot lot);
        public bool EditLot<T>(int id, T parameter, bool check);
        public Lot GetLot(int id);
        public IEnumerable<Lot> GetLots(string line);
        public IEnumerable<Lot> GetLots(double numberFrom, double numberTo);
        public IEnumerable<Lot> GetLots(string dateFrom, string dateTo);
        public bool AddUser(Account account);
        public bool DeleteUser(int id);
        public bool EditUserWithAllParameters(Account account);
        public bool EditUser<T>(int id, T parametr, bool check);
        public bool EditAccount(int id, string parametr, bool check);
        public bool EditRoleInAcoount(int id, string newRole);
        public Account GetAccount(int id);
        public User GetUser(int id);
        public IEnumerable<User> GetUsers(string line);
        public IEnumerable<User> GetUsers(string dateFrom, string dateTo);
        public IEnumerable<Lot> GetUserLots(int id);
        public int CheckAccount(string login, string password);
        public int CheckRole(int id);
        public bool AddLotForUser(int userID, int lotID);
        public bool DeleteLotForUser(int userID, int lotID);
        public int GetLastIdForLot();
        public int GetLastIdForUser();
    }
}
