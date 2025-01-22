using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BL.DTOs.DepartmentDTOs
{
    public class AddDepartmentDTO
    {
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class AddDepartmentDTOValidation : AbstractValidator<AddDepartmentDTO>
    {
        public AddDepartmentDTOValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required")
                .MaximumLength(50).WithMessage("Title can be maximum 50 characters.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required")
               .MaximumLength(250).WithMessage("Description can be maximum 250 characters.");
            RuleFor(x => x.Image)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Image cannot be null")
                .Must(x => x.Length < 5 * 1024 * 1024).WithMessage("Department is required");
        }
    }
}
