using BL.DTOs.AuthDTO;
using BL.Exceptions;
using BL.Services.Abstractions;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AccountController : Controller
    {
        readonly IAuthService _service;
        public AccountController(IAuthService service)
        {
            _service = service;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }
                await _service.LoginAsync(dto);
                return RedirectToAction("Index","Home");
            }
            catch (MainException ex)
            {
                ModelState.AddModelError("CustomError",ex.Message);
                return View(dto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }
                await _service.RegisterAsync(dto);
                return RedirectToAction("Login");
            }
            catch (MainException ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(dto);
            }
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await _service.LogoutAsync();
                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
