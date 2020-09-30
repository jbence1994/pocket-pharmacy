using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PocketPharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        // GET: api/<MedicinesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/<MedicinesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MedicinesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MedicinesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedicinesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
