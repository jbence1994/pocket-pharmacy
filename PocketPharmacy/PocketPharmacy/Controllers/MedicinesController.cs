using System;
using System.Collections.Generic;
using System.Security.Claims;
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
    [Authorize]
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
        public IActionResult GetMedicines()
        {
            try
            {
                var userId = Convert.ToInt32(
                    HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                );

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
        public IActionResult GetMedicine(int id)
        {
            try
            {
                var userId = Convert.ToInt32(
                    HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                );

                var medicine = _medicineRepository.GetMedicine(userId, id);
                var medicineResource = _mapper.Map<Medicine, GetMedicineResource>(medicine);

                return Ok(medicineResource);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/medicines/
        [HttpPost]
        public IActionResult AddMedicine([FromBody] SaveMedicineResource medicineResource)
        {
            try
            {
                var userId = Convert.ToInt32(
                    HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                );

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var medicine = _mapper.Map<SaveMedicineResource, Medicine>(medicineResource);
                medicine.LastUpdatedAt = DateTime.Now;
                medicine.UserId = userId;

                _medicineRepository.AddMedicine(medicine);
                _unitOfWork.Complete();

                medicine = _medicineRepository.GetMedicine(userId, medicine.Id);
                var result = _mapper.Map<Medicine, GetMedicineResource>(medicine);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/medicines/5
        //[HttpPut("{id}")]
        //public IActionResult UpdateMedicine(int id, [FromBody] SaveMedicineResource medicineResource)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        var medicine = _medicineRepository.GetMedicine(1, id);
        //        //medicine.LastUpdatedAt = DateTime.Now;

        //        //_mapper.Map(medicineResource, medicine);
        //        //_unitOfWork.Complete();

        //        //medicine = _medicineRepository.GetMedicine(medicine.Id);
        //        var result = _mapper.Map<Medicine, GetMedicineResource>(medicine);

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // DELETE: api/medicines/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMedicine(int id)
        {
            try
            {
                var userId = Convert.ToInt32(
                    HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                );

                _medicineRepository.DeleteMedicine(userId, id);
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
            try
            {
                var userId = Convert.ToInt32(
                    HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                );

                var medicine = _medicineRepository.GetMedicine(userId, id);
                var weeklyDosage = medicine.GetWeeklyDosage();

                return Ok(weeklyDosage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/medicines/5/isExpired
        [HttpGet("{id}/isExpired")]
        public IActionResult IsExpiredMedicine(int id)
        {
            try
            {
                var userId = Convert.ToInt32(
                    HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                );

                var medicine = _medicineRepository.GetMedicine(userId, id);
                var isExpiredMedicine = medicine.IsExpired();

                return Ok(isExpiredMedicine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/medicines/5/hasWeeklyDosage
        [HttpGet("{id}/hasWeeklyDosage")]
        public IActionResult HasWeeklyDosage(int id)
        {
            try
            {
                var userId = Convert.ToInt32(
                    HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                );

                var medicine = _medicineRepository.GetMedicine(userId, id);
                var hasWeeklyDosage = medicine.HasWeeklyDosage();

                return Ok(hasWeeklyDosage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
