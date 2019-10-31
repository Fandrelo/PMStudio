using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMStudio.Areas.Identity.Data;
using PMStudio.Models;
using PMStudio.Utils;

namespace PMStudio.Controllers
{
    [Authorize(Roles = SystemRoles.Administrator)]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<PMStudioUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<PMStudioUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Roles
        public async Task<ActionResult> Index()
        {
            var assignableRoles = await _roleManager.Roles.ToListAsync();
            return View(assignableRoles);
        }

        // GET: Roles/Assign
        public async Task<ActionResult> Assign()
        {
            var assignableRoles = await _roleManager.Roles.ToListAsync();
            ViewData["Name"] = new SelectList(assignableRoles, "Name", "Name");
            ViewData["UserName"] = new SelectList(_userManager.Users, "UserName", "UserName");
            return View(new RoleModel());
        }

        // POST: Roles/Assign
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Assign(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(roleModel.UserName);
                if (user != null)
                {
                    if (await _roleManager.RoleExistsAsync(roleModel.Name))
                    {
                        if (await _userManager.IsInRoleAsync(user, roleModel.Name))
                        {
                            ViewData["Message"] = $@"Usuario {roleModel.UserName} ya posee el rol de {roleModel.Name}";
                            return View("_Info");
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, roleModel.Name);
                            ViewData["Message"] = $@"Usuario {roleModel.UserName} ahora posee el rol de {roleModel.Name}";
                            return View("_Info");
                        }
                    }
                    else
                    {
                        ViewData["Message"] = "Petición Invalida";
                        return View("_Info");
                    }
                }
                else
                {
                    ViewData["Message"] = "Petición Invalida";
                    return View("_Info");
                }
            }
            return View(roleModel);
        }
    }
}