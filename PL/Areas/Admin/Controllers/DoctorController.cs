using AutoMapper;
using BL.DTOs.DoctorDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class DoctorController : Controller
    {
        readonly IDoctorService _doctorService;
        readonly IDepartmentService _departmentService;
        readonly IMapper _mapper;

        public DoctorController(IDepartmentService departmentService, IMapper mapper, IDoctorService doctorService)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<GetDoctorDTO> dto = await _doctorService.GetAllDoctorsAsync();
                return View(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Create()
        {
            try
            {
                AddDoctorDTO dto = new();
                dto.Departments = await _departmentService.SelectAllDepartmentsAsync();
                return View(dto);
            }
            catch(MainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddDoctorDTO dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(dto);
            //}
            try
            {
                await _doctorService.CreateDoctorAsync(dto);
                await _doctorService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (MainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Update(int Id)
        {
            try
            {
                GetDoctorDTO dto = await _doctorService.GetDoctorByIdAsync(Id);
                UpdateDoctorDTO updateDto = _mapper.Map<UpdateDoctorDTO>(dto);
                updateDto.Departments = await _departmentService.SelectAllDepartmentsAsync();
                return View(updateDto);
            }
            catch (MainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateDoctorDTO updateDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(updateDto);
            //}
            try
            {
                await _doctorService.UpdateDoctorAsync(updateDto);
                await _doctorService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (MainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _doctorService.DeleteDoctorAsync(Id);
                await _doctorService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (MainException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
