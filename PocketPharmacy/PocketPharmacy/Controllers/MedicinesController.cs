using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PocketPharmacy.Controllers.Resources.Medicine;
using PocketPharmacy.Core;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicinesController(IMedicineRepository medicineRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _medicineRepository = medicineRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/medicines/
        [HttpGet]
        [Authorize]
        public IActionResult GetMedicines([FromHeader] int userId)
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

        // GET: api/medicines/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetMedicine(int id, [FromHeader] int userId)
        {
            try
            {
                var medicine = _medicineRepository.GetMedicine(userId, id);
                var medicineResource = _mapper.Map<Medicine, GetMedicineResource>(medicine);

                return Ok(medicineResource);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ------- NEED TO REFACTOR --------------------------------------------------------

        // POST: api/medicines/
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromHeader] int userId, [FromBody] SaveMedicineResource medicineResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var medicine = _mapper.Map<SaveMedicineResource, Medicine>(medicineResource);
                medicine.LastUpdatedAt = DateTime.Now;

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
        [Authorize]
        public IActionResult Put(int id, [FromBody] SaveMedicineResource medicineResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var medicine = _medicineRepository.GetMedicine(id);
                medicine.LastUpdatedAt = DateTime.Now;

                _mapper.Map(medicineResource, medicine);

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

        // ------- NEED TO REFACTOR --------------------------------------------------------

        // DELETE: api/medicines/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _medicineRepository.DeleteMedicine(id);
                _unitOfWork.Complete();

                return Ok(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/medicines/5/getWeeklyDosage
        [HttpGet("{id}/getWeeklyDosage")]
        [Authorize]
        public IActionResult GetWeeklyDosage(int id)
        {
            throw new NotImplementedException("Végpont fejlesztés alatt...");
        }

        // GET: api/medicines/5/isExpired
        [HttpGet("{id}/isExpired")]
        [Authorize]
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

        // GET: api/medicines/5/hasWeeklyDosage
        [HttpGet("{id}/hasWeeklyDosage")]
        [Authorize]
        public IActionResult HasWeeklyDosage(int id)
        {
            throw new NotImplementedException("Végpont fejlesztés alatt...");
        }
    }
}
