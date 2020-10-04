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
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicinesController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        // GET: api/medicines
        [HttpGet]
        public IEnumerable<Medicine> Get()
        {
            return _medicineRepository.GetMedicines();
        }

        // GET: api/medicines/5
        [HttpGet("{id}")]
        public Medicine Get(int id)
        {
            return _medicineRepository.GetMedicine(id);
        }

        // POST: api/medicines
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/medicines
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/medicines/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
