using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PFE_EMI.Models.roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE_EMI.Controllers.roles
{
    [Authorize(Roles ="admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController (RoleManager<IdentityRole> role)
        {
            roleManager = role;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            var res = await roleManager.CreateAsync(new IdentityRole(role.roleName));
            if (res.Succeeded)
            {
                return View();
            }
            return View(role);
        }
    }
}
