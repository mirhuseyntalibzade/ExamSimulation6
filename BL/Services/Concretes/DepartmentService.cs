using AutoMapper;
using BL.DTOs.DepartmentDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using BL.Utilities;
using CORE.Models;
using DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BL.Services.Concretes
{
    public class DepartmentService : IDepartmentService
    {
        readonly IDeparmentRepository _repository;
        readonly IMapper _mapper;

        public DepartmentService(IMapper mapper, IDeparmentRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateDepartmentAsync(AddDepartmentDTO dto)
        {
            string imgPath = await UploadImage.SaveImage(dto.Image, "departments");
            Department department = _mapper.Map<Department>(dto);
            department.ImageURL = imgPath;
            await _repository.CreateAsync(department);
        }

        public async Task DeleteDepartmentAsync(int Id)
        {
            Department department = await _repository.GetByIdAsync(Id);
            if (department is null)
            {
                throw new MainException("Department cannot be found.");
            }
            _repository.Delete(department);
        }

        public async Task<ICollection<GetDepartmentDTO>> GetAllDepartmentsAsync()
        {
            return _mapper.Map<ICollection<GetDepartmentDTO>>(await _repository.GetAllAsync("Doctors"));
        }

        public async Task<GetDepartmentDTO> GetDepartmentByIdAsync(int Id)
        {
            Department department = await _repository.GetByIdAsync(Id, "Doctors");
            if (department is null)
            {
                throw new MainException("Department cannot be found.");
            }
            return _mapper.Map<GetDepartmentDTO>(department);
        }

        public async Task<int> SaveChangesAsync()
        {
            int result = await _repository.SaveChangesAsync();
            if (result == 0)
            {
                throw new MainException();
            }
            return result;
        }

        public Task<ICollection<SelectListItem>> SelectAllDepartmentsAsync()
        {
            return _repository.SelectAllDepartments();
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentDTO dto)
        {
            Department oldDepartment = await _repository.GetByIdAsync(dto.Id);
            if (oldDepartment is null)
            {
                throw new MainException("Department cannot be found.");
            }
            dto.CreatedAt = oldDepartment.CreatedAt;

            Department department = _mapper.Map<Department>(dto);
            if (dto.Image is null)
            {
                department.ImageURL = oldDepartment.ImageURL;
            }
            else
            {
                string imgPath = await UploadImage.SaveImage(dto.Image, "departments");
                department.ImageURL = imgPath;
            }

            _repository.Update(department);
        }
    }
}
