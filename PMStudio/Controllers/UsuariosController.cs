using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMStudio.Areas.Identity.Data;
using PMStudio.Models;
using PMStudio.Models.Entities;
using PMStudio.Utils;

namespace PMStudio.Controllers
{
    [Authorize(Roles = SystemRoles.AdministratorOrMember)]
    public class UsuariosController : Controller
    {
        private readonly PMStudioContext _context;
        private readonly UserManager<PMStudioUser> _userManager;

        public UsuariosController(
            PMStudioContext context,
            UserManager<PMStudioUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = SystemRoles.Administrator)]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users
                .Take(30)
                .ToListAsync();
            return View(users.OrderBy(u => u.Email));
        }

        [HttpGet]
        [Route("Usuarios/MisPasos")]
        public async Task<IActionResult> Steps()
        {
            var steps = await _context.PasosUsuariosDetalle
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.PasoNavigation)
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.EstadoNavigation)
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.InstanciaPlantillaNavigation)
                .Where(p => p.AspNetUser == User.FindFirstValue(ClaimTypes.NameIdentifier))
                .ToListAsync();
            return View(steps);
        }

        [HttpGet]
        [Route("Usuarios/MisPasos/Gestionar/{id}")]
        public async Task<IActionResult> ManageUserSteps(int id)
        {
            ViewData["Status"] = new SelectList(_context.Acciones.Where(a => a.IdAccion != 4), "IdAccion", "Nombre");
            var model = await _context.PasosUsuariosDetalle
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.PasoNavigation)
                        .ThenInclude(p => p.PasosInstanciasDatosDetalle)
                            .ThenInclude(p => p.InstanciaPlantillaDatoNavigation)
                                .ThenInclude(p => p.IdDatoTipoNavigation)
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.InstanciaPlantillaNavigation)
                        .ThenInclude(p => p.InstanciasPlantillasPasosDetalle)
                            .ThenInclude(p => p.PasoNavigation)
                .Where(p => p.IdPasosUsuarios == id)
                .FirstOrDefaultAsync();

            if(model.PlantillaPasoDetalleNavigation.Estado.GetValueOrDefault() == 3)
            {
                TempData["Warning"] = "El paso esta finalizado.";
                return RedirectToAction(nameof(Steps));
            }

            var stepsInInstance = model
                .PlantillaPasoDetalleNavigation
                .InstanciaPlantillaNavigation
                .InstanciasPlantillasPasosDetalle
                .OrderBy(p => p.PasoNavigation.IdPasoinstancia)
                .ToList();

            var pos = stepsInInstance.IndexOf(model.PlantillaPasoDetalleNavigation);

            for (int i = 0; i < pos; i++)
            {
                if(stepsInInstance[i].Estado.GetValueOrDefault() != 3)
                {
                    TempData["Warning"] = "Existen pasos anteriores NO finalizados.";
                    return RedirectToAction(nameof(Steps));
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Usuarios/MisPasos/Gestionar/{id}")]
        public async Task<IActionResult> ManageUserSteps(int id, PasosUsuariosDetalle step)
        {
            if (ModelState.IsValid)
            {
                var stepInDb = await _context.PasosUsuariosDetalle
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.PasoNavigation)
                        .ThenInclude(p => p.PasosInstanciasDatosDetalle)
                            .ThenInclude(p => p.InstanciaPlantillaDatoNavigation)
                                .ThenInclude(p => p.IdDatoTipoNavigation)
                .Where(p => p.IdPasosUsuarios == id)
                .FirstOrDefaultAsync();
                stepInDb.PlantillaPasoDetalleNavigation.Estado = step.PlantillaPasoDetalleNavigation.Estado;
                if(step.PlantillaPasoDetalleNavigation.Estado == 3)
                {
                    stepInDb.PlantillaPasoDetalleNavigation.PasoNavigation.FechaFin = DateTime.Now;
                }
                foreach (var i in step.PlantillaPasoDetalleNavigation.PasoNavigation.PasosInstanciasDatosDetalle)
                {
                    foreach (var j in stepInDb.PlantillaPasoDetalleNavigation.PasoNavigation.PasosInstanciasDatosDetalle)
                    {
                        if(i.IdPasosInstanciasDatos == j.IdPasosInstanciasDatos)
                        {
                            j.InstanciaPlantillaDatoNavigation.DatoTexto = i.InstanciaPlantillaDatoNavigation.DatoTexto;
                            j.InstanciaPlantillaDatoNavigation.DatoFecha = i.InstanciaPlantillaDatoNavigation.DatoFecha;
                            j.InstanciaPlantillaDatoNavigation.DatoNumerico = i.InstanciaPlantillaDatoNavigation.DatoNumerico;
                            j.InstanciaPlantillaDatoNavigation.DatoDecimal = i.InstanciaPlantillaDatoNavigation.DatoDecimal;
                        }
                    }
                }
                _context.PasosUsuariosDetalle.Update(stepInDb);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Actualizacion de paso exitoso.";
                return RedirectToAction(nameof(Steps));
            }
            else
            {
                ViewData["Status"] = new SelectList(_context.Acciones, "IdAccion", "Nombre");
                return View(step);
            }
        }

        [HttpGet]
        [Route("Usuarios/MisPasos/Redireccionar/{id}")]
        public async Task<IActionResult> RedirectUserSteps(int id)
        {
            ViewData["Status"] = new SelectList(_context.Acciones.Where(a => a.IdAccion != 4), "IdAccion", "Nombre");
            var currentUser = User.FindFirstValue(ClaimTypes.Name);
            ViewData["Users"] = new SelectList(_userManager.Users.Where(u => u.UserName != currentUser), "Id", "UserName");
            var model = await _context.PasosUsuariosDetalle
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.PasoNavigation)
                        .ThenInclude(p => p.PasosInstanciasDatosDetalle)
                            .ThenInclude(p => p.InstanciaPlantillaDatoNavigation)
                                .ThenInclude(p => p.IdDatoTipoNavigation)
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.InstanciaPlantillaNavigation)
                        .ThenInclude(p => p.InstanciasPlantillasPasosDetalle)
                            .ThenInclude(p => p.PasoNavigation)
                .Where(p => p.IdPasosUsuarios == id)
                .FirstOrDefaultAsync();

            if (model.PlantillaPasoDetalleNavigation.Estado.GetValueOrDefault() == 3)
            {
                TempData["Warning"] = "El paso esta finalizado, no se puede redireccionar.";
                return RedirectToAction(nameof(Steps));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Usuarios/MisPasos/Redireccionar/{id}")]
        public async Task<IActionResult> RedirectUserSteps(int id, PasosUsuariosDetalle step)
        {
            if (ModelState.IsValid)
            {
                var stepInDb = await _context.PasosUsuariosDetalle
                    .Where(p => p.IdPasosUsuarios == id)
                    .FirstOrDefaultAsync();
                stepInDb.AspNetUser = step.AspNetUser;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Paso redireccionado exitosamente.";
                return RedirectToAction(nameof(Steps));
            }
            else
            {
                ViewData["Status"] = new SelectList(_context.Acciones, "IdAccion", "Nombre");
                var currentUser = User.FindFirstValue(ClaimTypes.Name);
                ViewData["Users"] = new SelectList(_userManager.Users.Where(u => u.UserName != currentUser), "Id", "UserName");
                return View(step);
            }
        }

        [HttpGet]
        [Route("Usuarios/MisPasos/Denegar/{id}")]
        public async Task<IActionResult> DenyUserSteps(int id)
        {
            var model = await _context.PasosUsuariosDetalle
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.PasoNavigation)
                        .ThenInclude(p => p.PasosInstanciasDatosDetalle)
                            .ThenInclude(p => p.InstanciaPlantillaDatoNavigation)
                                .ThenInclude(p => p.IdDatoTipoNavigation)
                .Include(p => p.PlantillaPasoDetalleNavigation)
                    .ThenInclude(p => p.InstanciaPlantillaNavigation)
                        .ThenInclude(p => p.InstanciasPlantillasPasosDetalle)
                            .ThenInclude(p => p.PasoNavigation)
                .Where(p => p.IdPasosUsuarios == id)
                .FirstOrDefaultAsync();

            if (model.PlantillaPasoDetalleNavigation.Estado.GetValueOrDefault() == 3)
            {
                TempData["Warning"] = "El paso esta finalizado, no se puede rechazar.";
                return RedirectToAction(nameof(Steps));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Usuarios/MisPasos/Denegar/{id}")]
        public async Task<IActionResult> DenyUserSteps(int id, PasosUsuariosDetalle step)
        {
            if (ModelState.IsValid)
            {
                var stepInDb = await _context.PasosUsuariosDetalle
                    .Include(p => p.PlantillaPasoDetalleNavigation)
                        .ThenInclude(p => p.PasoNavigation)
                            .ThenInclude(p => p.PasosInstanciasDatosDetalle)
                                .ThenInclude(p => p.InstanciaPlantillaDatoNavigation)
                                    .ThenInclude(p => p.IdDatoTipoNavigation)
                    .Include(p => p.PlantillaPasoDetalleNavigation)
                        .ThenInclude(p => p.InstanciaPlantillaNavigation)
                            .ThenInclude(p => p.InstanciasPlantillasPasosDetalle)
                                .ThenInclude(p => p.PasoNavigation)
                    .Where(p => p.IdPasosUsuarios == id)
                    .FirstOrDefaultAsync();
                stepInDb.PlantillaPasoDetalleNavigation.Estado = 4;
                stepInDb.PlantillaPasoDetalleNavigation.InstanciaPlantillaNavigation.Estado = "Rechazada";
                stepInDb.PlantillaPasoDetalleNavigation.PasoNavigation.FechaFin = DateTime.Now;
                foreach (var item in stepInDb
                    .PlantillaPasoDetalleNavigation
                    .InstanciaPlantillaNavigation
                    .InstanciasPlantillasPasosDetalle.Where(p => p.IdPlantillaPasoDetalle >= stepInDb.PlantillaPasoDetalleNavigation.IdPlantillaPasoDetalle))
                {
                    item.Estado = 4;
                }
                _context.PasosUsuariosDetalle.Update(stepInDb);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Paso rechazado exitosamente.";
                return RedirectToAction(nameof(Steps));
            }
            else
            {
                return View(step);
            }
        }

        [Authorize(Roles = SystemRoles.Administrator)]
        [HttpGet]
        [Route("Usuarios/Eliminar/{userName}")]
        public async Task<IActionResult> Delete(string userName)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                NotFound();
            }
            return View(user);
        }

        [Authorize(Roles = SystemRoles.Administrator)]
        [HttpPost]
        [Route("Usuarios/Eliminar/{userName}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string userName)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                NotFound();
            }

            var userEmail = user.Email;

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                TempData["Warning"] = "El usuario no ha podido ser eliminado (Ya no existe?).";
            }
            else
            {
                TempData["Success"] = $"El usuario {userEmail} fue eliminado exitosamente.";
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = SystemRoles.Administrator)]
        [HttpGet]
        [Route("Usuarios/AsignarPasos/{userName}")]
        public async Task<IActionResult> AssignSteps(string userName)
        {
            ViewData["UserName"] = userName;
            return View();
        }
    }
}