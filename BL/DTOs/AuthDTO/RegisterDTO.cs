using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.AuthDTO
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address cannot be empty")
                .EmailAddress()
                .WithMessage("Email address is not supported.")
                .MinimumLength(5).WithMessage("Minimum length is 5 characters only.")
                .MaximumLength(50).WithMessage("Maximum length is 50 characters only.");
            
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username address cannot be empty")
                .MinimumLength(5).WithMessage("Minimum length is 5 characters only.")
                .MaximumLength(50).WithMessage("Maximum length is 50 characters only.");

            RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password cannot be empty!")
            .MinimumLength(4).WithMessage("Password must be at least 4 symbols long!");

            RuleFor(e => e.RepeatPassword)
                .NotEmpty().WithMessage("Password cannot be empty!")
                .Equal(e => e.Password).WithMessage("Passwords don't match!");
        }
    }
}
