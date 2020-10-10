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
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicinesController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        // GET: api/medicines
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_medicineRepository.GetMedicines());
        }

        // GET: api/medicines/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_medicineRepository.GetMedicine(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/medicines/5/dosage
        [HttpGet("{id}/dosage")]
        public IActionResult GetMedicineDosage(int id)
        {
            try
            {
                return Ok(_medicineRepository.GetDosage(medicineId: id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/medicines
        [HttpPost]
        public IActionResult Post([FromBody] Medicine medicine)
        {
            throw new NotImplementedException();
        }

        // PUT: api/medicines
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Medicine medicine)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/medicines/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
