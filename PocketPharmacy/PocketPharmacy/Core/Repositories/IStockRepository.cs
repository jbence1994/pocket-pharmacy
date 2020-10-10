using PocketPharmacy.Core.Models;
using System.Collections.Generic;

namespace PocketPharmacy.Core.Repositories
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetStocks();
        Stock GetStock(int id);
    }
}
