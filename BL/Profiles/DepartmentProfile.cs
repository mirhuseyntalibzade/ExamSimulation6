using AutoMapper;
using BL.DTOs.DepartmentDTOs;
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, AddDepartmentDTO>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDTO>().ReverseMap();
            CreateMap<Department, GetDepartmentDTO>().ReverseMap();
            CreateMap<UpdateDepartmentDTO, GetDepartmentDTO>().ReverseMap();
        }
    }
}
