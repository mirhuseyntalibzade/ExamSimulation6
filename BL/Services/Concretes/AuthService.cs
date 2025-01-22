using BL.DTOs.AuthDTO;
using BL.Exceptions;
using BL.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Concretes
{
    public class AuthService : IAuthService
    {
        readonly SignInManager<IdentityUser> _signInManager;
        readonly UserManager<IdentityUser> _userManager;

        public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task LoginAsync(LoginDTO loginDTO)
        {
            IdentityUser? user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user is null)
            {
                throw new MainException("Credentials are not correct");
            }
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password,true);
            if (!result.Succeeded)
            {
                throw new MainException("Credentials are not correct");
            }
            await _signInManager.SignInAsync(user,true);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            IdentityUser user = new()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.UserName,
            };
            IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                throw new MainException();
            }
            result = await _userManager.AddToRoleAsync(user, "User");
            if (!result.Succeeded)
            {
                throw new MainException();
            }
        }
    }
}
