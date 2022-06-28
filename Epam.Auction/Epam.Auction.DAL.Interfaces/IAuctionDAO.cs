using Epam.Auction.Common.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Auction.DAL.Interfaces
{
    public interface IAuctionDAO
    {
        bool addLot(Lot lot);
        bool deleteLot(int id);
        bool editLot(Lot lot);
        IEnumerable<Lot> getLots();
        Lot getLot(int id);

    }
}
