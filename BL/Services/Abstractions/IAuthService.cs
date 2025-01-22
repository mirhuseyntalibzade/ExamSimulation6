using BL.DTOs.AuthDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Abstractions
{
    public interface IAuthService
    {
        public Task LoginAsync(LoginDTO loginDTO);
        public Task RegisterAsync(RegisterDTO registerDTO);
        public Task LogoutAsync();
    }
}
