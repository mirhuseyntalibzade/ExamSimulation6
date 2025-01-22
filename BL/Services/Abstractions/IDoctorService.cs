using BL.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Abstractions
{
    public interface IDoctorService
    {
        public Task CreateDoctorAsync(AddDoctorDTO dto);
        public Task UpdateDoctorAsync(UpdateDoctorDTO dto);
        public Task DeleteDoctorAsync(int Id);
        public Task<ICollection<GetDoctorDTO>> GetAllDoctorsAsync();
        public Task<GetDoctorDTO> GetDoctorByIdAsync(int Id);
        public Task<int> SaveChangesAsync();
    }
}
