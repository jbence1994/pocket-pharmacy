using System;
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
        public IActionResult Get()
        {
            return Ok(_stockRepository.GetStocks());
        }

        // GET api/stocks>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_stockRepository.GetStock(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/stocks
        [HttpPost]
        public IActionResult Post([FromBody] Stock stock)
        {
            throw new NotImplementedException();
        }

        // PUT api/stocks
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Stock stock)
        {
            throw new NotImplementedException();
        }

        // DELETE api/stocks
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
