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
        bool addLot(Lot lot);
        void deleteLot(int id);
        void deleteLot(Lot lot);
        void editLot(Lot lot);
        IEnumerable<Lot> getLots();
        //IEnumerable<Lot> getLots(string letter);
        //IEnumerable<Lot> getLots(float price1, float price2);
        Lot getLot(int id);
    }
}
