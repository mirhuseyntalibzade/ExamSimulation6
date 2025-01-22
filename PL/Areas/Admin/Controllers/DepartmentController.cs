using AutoMapper;
using BL.DTOs.DepartmentDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]

    public class DepartmentController : Controller
    {
        readonly IDepartmentService _departmentService;
        readonly IMapper _mapper;

        public DepartmentController(IMapper mapper, IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ICollection<GetDepartmentDTO> dto = await _departmentService.GetAllDepartmentsAsync();
                return View(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddDepartmentDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }
                await _departmentService.CreateDepartmentAsync(dto);
                await _departmentService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (MainException ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
        }

        public async Task<IActionResult> Update(int Id)
        {
            try
            {
                GetDepartmentDTO dto = await _departmentService.GetDepartmentByIdAsync(Id);
                return View(_mapper.Map<UpdateDepartmentDTO>(dto));
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
        public async Task<IActionResult> Update(UpdateDepartmentDTO updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(updateDto);
                }
                await _departmentService.UpdateDepartmentAsync(updateDto);
                await _departmentService.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (MainException ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(updateDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(updateDto);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _departmentService.DeleteDepartmentAsync(Id);
                await _departmentService.SaveChangesAsync();
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
