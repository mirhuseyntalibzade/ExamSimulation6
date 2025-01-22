using AutoMapper;
using BL.DTOs.DoctorDTOs;
using BL.Exceptions;
using BL.Services.Abstractions;
using BL.Utilities;
using CORE.Models;
using DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Concretes
{
    public class DoctorService : IDoctorService
    {
        readonly IDoctorRepository _repository;
        readonly IMapper _mapper;
        public DoctorService(IMapper mapper, IDoctorRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateDoctorAsync(AddDoctorDTO dto)
        {
            string imgPath = await UploadImage.SaveImage(dto.Image, "doctors");
            Doctor department = _mapper.Map<Doctor>(dto);
            department.ImageURL = imgPath;
            await _repository.CreateAsync(department);
        }

        public async Task DeleteDoctorAsync(int Id)
        {
            Doctor department = await _repository.GetByIdAsync(Id);
            if (department is null)
            {
                throw new MainException("Doctor cannot be found.");
            }
            _repository.Delete(department);
        }

        public async Task<ICollection<GetDoctorDTO>> GetAllDoctorsAsync()
        {
            return _mapper.Map<ICollection<GetDoctorDTO>>(await _repository.GetAllAsync());
        }

        public async Task<GetDoctorDTO> GetDoctorByIdAsync(int Id)
        {
            Doctor department = await _repository.GetByIdAsync(Id);
            if (department is null)
            {
                throw new MainException("Doctor cannot be found.");
            }
            return _mapper.Map<GetDoctorDTO>(department);
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

        public async Task UpdateDoctorAsync(UpdateDoctorDTO dto)
        {
            Doctor oldDoctor = await _repository.GetByIdAsync(dto.Id);
            if (oldDoctor is null)
            {
                throw new MainException("Doctor cannot be found.");
            }
            dto.CreatedAt = oldDoctor.CreatedAt;

            Doctor department = _mapper.Map<Doctor>(dto);
            if (dto.Image is null)
            {
                department.ImageURL = oldDoctor.ImageURL;
            }
            else
            {
                string imgPath = await UploadImage.SaveImage(dto.Image, "doctors");
                department.ImageURL = imgPath;
            }

            _repository.Update(department);
        }
    }
}
