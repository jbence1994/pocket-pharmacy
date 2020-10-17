using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PocketPharmacy.Controllers.Resources;
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
        private readonly IMapper _mapper;

        public MedicinesController(IMedicineRepository medicineRepository, IMapper mapper)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }

        // GET: api/medicines/user=5
        [HttpGet("user={userId}")]
        public IActionResult GetMedicines(int userId)
        {
            try
            {
                var medicines = _medicineRepository.GetMedicines(userId);
                var medicineResources = _mapper.Map<IEnumerable<Medicine>, IEnumerable<MedicineResource>>(medicines);

                return Ok(medicineResources);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/medicines/user=5/medicine=5
        [HttpGet("user={userId}/medicine={medicineId}")]
        public IActionResult GetMedicine(int userId, int medicineId)
        {
            try
            {
                var medicine = _medicineRepository.GetMedicine(userId, medicineId);
                var medicineResource = _mapper.Map<Medicine, MedicineResource>(medicine);

                return Ok(medicineResource);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/medicines
        [HttpPost]
        public IActionResult Post([FromBody] MedicineResource medicineResource)
        {
            try
            {
                var medicine = _mapper.Map<MedicineResource, Medicine>(medicineResource);
                _medicineRepository.AddMedicine(medicine);

                return Ok(medicineResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/medicines
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MedicineResource medicine)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/medicines/user=5/medicine=5

        [HttpDelete("user={userId}/medicine={medicineId}")]
        public IActionResult Delete(int userId, int medicineId)
        {
            try
            {
                _medicineRepository.DeleteMedicine(medicineId);

                return Ok(medicineId);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}/isExpired")]
        public IActionResult IsExpiredMedicine(int id)
        {
            try
            {
                var isExpiredMedicine = _medicineRepository.IsExpiredMedicine(id);
                return Ok(isExpiredMedicine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
