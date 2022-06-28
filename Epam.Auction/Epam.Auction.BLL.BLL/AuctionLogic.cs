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

        public bool addLot(Lot lot) => _auctionDAO.addLot(lot);

        public void deleteLot(int id) => _auctionDAO.deleteLot(id);

        public void deleteLot(Lot lot) => deleteLot(lot.id);

        public void editLot(Lot lot) => _auctionDAO.editLot(lot);

        public Lot getLot(int id) => _auctionDAO.getLot(id);

        public IEnumerable<Lot> getLots() => _auctionDAO.getLots();

        //public IEnumerable<Lot> getLots(string letter)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Lot> getLots(float price1, float price2)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
