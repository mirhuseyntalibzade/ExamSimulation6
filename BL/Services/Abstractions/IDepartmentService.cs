using BL.DTOs.DepartmentDTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Abstractions
{
    public interface IDepartmentService
    {
        public Task CreateDepartmentAsync(AddDepartmentDTO dto);
        public Task UpdateDepartmentAsync(UpdateDepartmentDTO dto);
        public Task DeleteDepartmentAsync(int Id);
        public Task<ICollection<SelectListItem>> SelectAllDepartmentsAsync();
        public Task<ICollection<GetDepartmentDTO>> GetAllDepartmentsAsync();
        public Task<GetDepartmentDTO> GetDepartmentByIdAsync(int Id);
        public Task<int> SaveChangesAsync();
    }
}
