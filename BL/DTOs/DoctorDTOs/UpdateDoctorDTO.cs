using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.DoctorDTOs
{
    public class UpdateDoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SelectListItem> Departments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class UpdateDoctorDTOValidation : AbstractValidator<UpdateDoctorDTO>
    {
        public UpdateDoctorDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Name can be maximum 50 characters.");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Department is required");
            RuleFor(x => x.Image)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Image cannot be null")
                .Must(x => x.Length < 5 * 1024 * 1024).WithMessage("Department is required")
                .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png")).WithMessage("Image only suports image type (jpeg,jpg,png)");
        }
    }
}
