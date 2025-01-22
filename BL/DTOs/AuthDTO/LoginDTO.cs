using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.AuthDTO
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class  LoginDTOValidator: AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address cannot be empty")
                .EmailAddress()
                .WithMessage("Email address is not supported.")
                .MaximumLength(5).WithMessage("Minimum length is 5 characters only.")
                .MaximumLength(50).WithMessage("Maximum length is 50 characters only.");


            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty")
                .MaximumLength(5).WithMessage("Minimum length is 5 characters only.")
                .MaximumLength(50).WithMessage("Maximum length is 50 characters only.");
        }
    }
}
