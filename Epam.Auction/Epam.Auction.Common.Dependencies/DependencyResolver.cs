using Epam.Auction.BLL.BLL;
using Epam.Auction.BLL.Interfaces;
using Epam.Auction.DAL.Interfaces;
using Epam.Auction.DAL.SqlDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.Common.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETONE
        private static DependencyResolver _instance;
        public static DependencyResolver Instance => _instance ??= new DependencyResolver();
        #endregion

        public IAuctionDAO auctionDAO => new AuctionSqlDAO();

        public IAuctionLogic auctionLogic => new AuctionLogic(auctionDAO);
    }
}
