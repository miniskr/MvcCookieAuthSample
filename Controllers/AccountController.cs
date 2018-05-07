using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCookieAuthSample.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MvcCookieAuthSample.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult MakeLogin()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "jsees"),
                new Claim(ClaimTypes.Role, "admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Ok();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Ok();
        }
    }
}