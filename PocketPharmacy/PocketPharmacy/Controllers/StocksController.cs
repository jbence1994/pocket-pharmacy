using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;

namespace PocketPharmacy.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StocksController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        // GET: api/stocks
        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            return _stockRepository.GetStocks();
        }

        // GET api/stocks>/5
        [HttpGet("{id}")]
        public Stock Get(int id)
        {
            return _stockRepository.GetStock(id);
        }

        // POST api/stocks
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/stocks
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/stocks
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
