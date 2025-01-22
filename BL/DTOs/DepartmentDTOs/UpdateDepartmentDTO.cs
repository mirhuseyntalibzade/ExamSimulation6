using BL.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.DepartmentDTOs
{
    public class UpdateDepartmentDTO
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class UpdateDepartmentDTOValidation : AbstractValidator<UpdateDepartmentDTO>
    {
        public UpdateDepartmentDTOValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required")
                .MaximumLength(50).WithMessage("Title can be maximum 50 characters.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required")
               .MaximumLength(250).WithMessage("Description can be maximum 250 characters.");
            RuleFor(x => x.Image)
                .Cascade(CascadeMode.Stop)
                .Must(x => x is null || x.Length < 5 * 1024 * 1024).WithMessage("DImage length cannot be bigger than 5mb.")
                .Must(x => x is null || x.CheckType("image")).WithMessage("File must be image!");
        }
    }
}
