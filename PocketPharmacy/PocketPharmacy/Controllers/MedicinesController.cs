using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PocketPharmacy.Core;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;
using PocketPharmacy.Resources;

namespace PocketPharmacy.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicinesController(IMedicineRepository medicineRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _medicineRepository = medicineRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/medicines/user=5
        [HttpGet("user={userId}")]
        public IActionResult GetMedicines(int userId)
        {
            try
            {
                var medicines = _medicineRepository.GetMedicines(userId);
                var medicineResources = _mapper.Map<IEnumerable<Medicine>, IEnumerable<GetMedicineResource>>(medicines);

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
                var medicineResource = _mapper.Map<Medicine, SaveMedicineResource>(medicine);

                return Ok(medicineResource);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/medicines/
        [HttpPost]
        public IActionResult Post([FromBody] SaveMedicineResource medicineResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var medicine = _mapper.Map<SaveMedicineResource, Medicine>(medicineResource);
                _medicineRepository.AddMedicine(medicine);

                _unitOfWork.Complete();

                medicine = _medicineRepository.GetMedicine(medicine.Id);
                var result = _mapper.Map<Medicine, GetMedicineResource>(medicine);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/medicines/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SaveMedicineResource medicineResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var medicine = _medicineRepository.GetMedicine(id);
                _mapper.Map<SaveMedicineResource, Medicine>(medicineResource, medicine);

                _unitOfWork.Complete();

                medicine = _medicineRepository.GetMedicine(medicine.Id);
                var result = _mapper.Map<Medicine, GetMedicineResource>(medicine);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/medicines/user=5/medicine=5
        [HttpDelete("user={userId}/medicine={medicineId}")]
        public IActionResult Delete(int medicineId)
        {
            try
            {
                _medicineRepository.DeleteMedicine(medicineId);
                _unitOfWork.Complete();

                return Ok(medicineId);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/medicines/5/isExpired
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
