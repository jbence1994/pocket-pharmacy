using System;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;
using System.Collections.Generic;

namespace PocketPharmacy.Persistence.Mocks
{
    public class FakeStockRepository : IStockRepository
    {
        private readonly List<Stock> _stocks;

        public FakeStockRepository()
        {
            _stocks = new List<Stock>
            {
                new Stock
                {
                    Id = 1,
                    User = new User
                    {
                        Id = 1,
                        Username = "jbence",
                        Password = "12345"
                    },
                    Medicine = new Medicine
                    {
                        Id = 1,
                        Name = "Xanax",
                        ExpirationDate = new DateTime(2021, 01, 01),
                        Dosage = new Dosage
                        {
                            PerDays = 1,
                            Amount = 30,
                            Unit = "mg"
                        }
                    }
                }
            };
        }

        public IEnumerable<Stock> GetStocks()
        {
            return _stocks;
        }

        public Stock GetStock(int id)
        {
            return _stocks.Find(stock => stock.Id == id);
        }
    }
}
