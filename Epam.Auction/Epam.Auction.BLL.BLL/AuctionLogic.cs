using Epam.Auction.BLL.Interfaces;
using Epam.Auction.Common.Entites;
using Epam.Auction.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.BLL.BLL
{
    public class AuctionLogic : IAuctionLogic
    {
        private IAuctionDAO _auctionDAO;

        public AuctionLogic(IAuctionDAO auctionDAO)
        {
            _auctionDAO = auctionDAO;
        }

        #region METHODS FOR LOTS
        public bool AddLot(Lot lot) 
            => _auctionDAO.AddLot(lot);
        
        public bool DeleteLot(int id)
            => _auctionDAO.DeleteLot(id);

        public bool EditLotWithAllParameters(Lot lot)
            => _auctionDAO.EditLotWithAllParameters(lot); 

        public bool EditLot<T>(int id, T parameter, bool check)
        {
            var lot = GetLot(id);
            if (lot != null)
            {
                if (ReferenceEquals(parameter.GetType(), "".GetType()))
                {
                    if (check)
                    {
                        lot.Name = parameter as string;
                        return EditLotWithAllParameters(lot);
                    } else
                    {
                        lot.Description = parameter as string;
                        return EditLotWithAllParameters(lot);
                    }
                }
                else if (ReferenceEquals(parameter.GetType(), (1.0).GetType()))
                {
                    lot.Price = Convert.ToDouble(parameter);
                    return EditLotWithAllParameters(lot);
                }
                throw new InvalidOperationException("Invalid parameter for user search");
            }
            throw new InvalidOperationException("Cannot find lot with ID = " + id);
        }

        public Lot GetLot(int id)
            => _auctionDAO.GetLot(id);

        public IEnumerable<Lot> GetLots(string line)
            => _auctionDAO.GetLots(line);

        public IEnumerable<Lot> GetLots(double numberFrom, double numberTo)
            => _auctionDAO.GetLots(numberFrom, numberTo);

        public IEnumerable<Lot> GetLots(string dateFrom, string dateTo)
            => _auctionDAO.GetLots(dateFrom, dateTo);

        public bool AddLotForUser(int userID, int lotID)
            => _auctionDAO.AddLotForUser(userID, lotID);

        public bool DeleteLotForUser(int userID, int lotID)
            => _auctionDAO.DeleteLotForUser(userID, lotID);

        public int GetLastIdForLot() 
            => _auctionDAO.GetLastIdForLot();
        #endregion

        #region METHODS FOR USERS
        public bool AddUser(Account account)
            => _auctionDAO.AddUser(account);

        public bool DeleteUser(int id)
            => _auctionDAO.DeleteUser(id);

        public bool EditUserWithAllParameters(Account account)
            => _auctionDAO.EditUserWithAllParameters(account);

        public bool EditUser<T>(int id, T parametr, bool check)
        {
            var account = GetAccount(id);
            if (account != null)
            {
                if (ReferenceEquals(parametr.GetType(), "".GetType()))
                {
                    if (check)
                    {
                        account.Name = parametr as string;
                        return EditUserWithAllParameters(account);
                    }
                    else
                    {
                        account.Email = parametr as string;
                        return EditUserWithAllParameters(account);
                    }
                }
                else if (ReferenceEquals(parametr.GetType(), DateTime.Parse("01.01.1900").GetType()))
                {
                    account.Birthdate = Convert.ToDateTime(parametr);
                    return EditUserWithAllParameters(account);
                }
                throw new InvalidOperationException("Invalid parameter for user search");
            }
            throw new InvalidOperationException("Cannot find lot with ID = " + id);

        }

        public bool EditAccount(int id, string parametr, bool check)
        { 
            var account = GetAccount(id);
            if (account != null)
            {
                if (check)
                {
                    account.Login = parametr as string;
                    return EditUserWithAllParameters(account);
                }
                else
                {
                    account.Password = parametr as string;
                    return EditUserWithAllParameters(account);
                }
            }
            throw new InvalidOperationException("Cannot find lot with ID = " + id);
        }

        public bool EditRoleInAcoount(int id, string newRole)
            => _auctionDAO.EditRoleInAccount(id, newRole);

        public Account GetAccount(int id) 
            => _auctionDAO.GetAccount(id);

        public User GetUser(int id)
            => _auctionDAO.GetUser(id);

        public IEnumerable<User> GetUsers(string line)
            => _auctionDAO.GetUsers(line);

        public IEnumerable<User> GetUsers(string dateFrom, string dateTo)
            => _auctionDAO.GetUsers(dateFrom, dateTo);

        public IEnumerable<Lot> GetUserLots(int id)
            => _auctionDAO.GetUserLots(id);

        public int CheckAccount(string login, string password)
            => _auctionDAO.CheckAccount(login, password);

        public int CheckRole(int id)
            => _auctionDAO.CheckRole(id);

        public int GetLastIdForUser()
            => _auctionDAO.GetLastIdForUser();
        #endregion
    }
}
