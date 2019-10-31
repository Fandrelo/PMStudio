using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = SystemRoles.Administrator)]
    public class PlantillasController : Controller
    {
        private readonly PMStudioContext _context;
        private readonly UserManager<PMStudioUser> _userManager;

        public PlantillasController(PMStudioContext context, UserManager<PMStudioUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Plantillas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plantillas.ToListAsync());
        }

        // GET: Plantillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantillas = await _context.Plantillas
                .Include(p => p.PlantillasPasosDetalle)
                    .ThenInclude(p => p.PasoNavigation)
                .Include(p => p.PlantillasPasosDetalle)
                    .ThenInclude(p => p.PlantillasPasosUsuariosDetalle)
                        .ThenInclude(p => p.AspNetUserNavigation)
                .Include(p => p.PlantillasCamposDetalle)
                    .ThenInclude(p => p.IdDatoTipoNavigation)
                .Include(p => p.PlantillasCamposDetalle)
                    .ThenInclude(p => p.PasosPlantillasCamposDetalle)
                .FirstOrDefaultAsync(m => m.IdPlantilla == id);
            if (plantillas == null)
            {
                return NotFound();
            }

            return View(plantillas);
        }

        // GET: Plantillas/Create
        [Route("Plantillas/Create")]
        [Route("Plantillas/Create/{steps}/{fields}")]
        public IActionResult Create(int? steps, int? fields)
        {
            var templateSteps = new List<PlantillasPasosDetalle>();
            for (int i = 0; i < steps.GetValueOrDefault(); i++)
            {
                templateSteps
                    .Add(new PlantillasPasosDetalle() { PlantillasPasosUsuariosDetalle = new List<PlantillasPasosUsuariosDetalle>()});
            }
            var templateFields = new List<PlantillasCamposDetalle>();
            for (int i = 0; i < fields.GetValueOrDefault(); i++)
            {
                templateFields
                    .Add(new PlantillasCamposDetalle());
            }
            var model = new Plantillas
            {
                PlantillasPasosDetalle = templateSteps,
                PlantillasCamposDetalle = templateFields
            };
            SetupCreateViewBag(model);
            return View(model);
        }

        [HttpPost]
        [Route("Plantillas/LinkStepsAndFields")]
        public IActionResult LinkStepsAndFields(Plantillas plantilla)
        {
            plantilla.PasosPlantillasCamposDetalle
                .Add(new PasosPlantillasCamposDetalle());
            SetupCreateViewBag(plantilla);
            return View(nameof(Create), plantilla);
        }

        [HttpPost]
        [Route("Plantillas/AddStep")]
        public IActionResult AddStep(Plantillas plantilla)
        {
            plantilla.PlantillasPasosDetalle
                .Add(new PlantillasPasosDetalle() { PlantillasPasosUsuariosDetalle = new List<PlantillasPasosUsuariosDetalle>() });
            SetupCreateViewBag(plantilla);
            return View(nameof(Create), plantilla);
        }

        [HttpPost]
        [Route("Plantillas/AddField")]
        public IActionResult AddField(Plantillas plantilla)
        {
            plantilla.PlantillasCamposDetalle
                .Add(new PlantillasCamposDetalle());
            SetupCreateViewBag(plantilla);
            return View(nameof(Create), plantilla);
        }

        [HttpPost]
        [Route("Plantillas/AddUser/{step}")]
        public IActionResult AddUser(Plantillas plantilla, int step)
        {
            plantilla.PlantillasPasosDetalle[step].PlantillasPasosUsuariosDetalle.Add(new PlantillasPasosUsuariosDetalle());
            SetupCreateViewBag(plantilla);
            return View(nameof(Create), plantilla);
        }

        // POST: Plantillas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Plantillas/Create")]
        public async Task<IActionResult> Create(Plantillas plantillas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantillas);
                var counter = 0;
                foreach (var item in plantillas.PlantillasPasosDetalle)
                {
                    counter++;

                    item.PasoNavigation.Numero = counter;
                }
                await _context.SaveChangesAsync();
                var stepsAndFieldsLinks = plantillas.PasosPlantillasCamposDetalle;
                foreach (var link in stepsAndFieldsLinks)
                {
                    link.Paso = 
                        plantillas.PlantillasPasosDetalle[link.Paso].PasoNavigation.IdPaso;
                    link.PlantillaCampo = 
                        plantillas.PlantillasCamposDetalle[link.PlantillaCampo].IdPlantillaCampo;
                }
                _context.AddRange(stepsAndFieldsLinks);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Plantilla creada exitosamente";
                return RedirectToAction(nameof(Index));
            }
            SetupCreateViewBag(plantillas);
            return View(plantillas);
        }

        private void SetupCreateViewBag(Plantillas plantilla)
        {
            var steps = new List<SelectListItem>();
            for(int i = 0; i < plantilla.PlantillasPasosDetalle.Count; i++)
            {
                if(plantilla.PlantillasPasosDetalle[i].PasoNavigation == null)
                {
                    break;
                }
                steps.Add(
                    new SelectListItem
                    {
                        Text = plantilla.PlantillasPasosDetalle[i].PasoNavigation.Nombre,
                        Value = i.ToString()
                    });
            }
            ViewData["Steps"] = steps;
            var fields = new List<SelectListItem>();
            for (int i = 0; i < plantilla.PlantillasCamposDetalle.Count; i++)
            {
                if (string.IsNullOrEmpty(plantilla.PlantillasCamposDetalle[i].NombreCampo))
                {
                    break;
                }
                fields.Add(
                    new SelectListItem
                    {
                        Text = plantilla.PlantillasCamposDetalle[i].NombreCampo,
                        Value = i.ToString()
                    });
            }
            ViewData["Fields"] = fields;
            ViewData["DataTypes"] = new SelectList(_context.DatoTipo, "IdDatoTipo", "Nombre");
            ViewData["Users"] = new SelectList(_userManager.Users, "Id", "UserName");
        }

        // GET: Plantillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantillas = await _context.Plantillas.FindAsync(id);
            if (plantillas == null)
            {
                return NotFound();
            }
            return View(plantillas);
        }

        // POST: Plantillas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlantilla,Nombre,Descripcion")] Plantillas plantillas)
        {
            if (id != plantillas.IdPlantilla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plantillas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantillasExists(plantillas.IdPlantilla))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(plantillas);
        }

        // GET: Plantillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantillas = await _context.Plantillas
                .FirstOrDefaultAsync(m => m.IdPlantilla == id);
            if (plantillas == null)
            {
                return NotFound();
            }

            return View(plantillas);
        }

        // POST: Plantillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantillas = await _context.Plantillas.FindAsync(id);
            _context.Plantillas.Remove(plantillas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantillasExists(int id)
        {
            return _context.Plantillas.Any(e => e.IdPlantilla == id);
        }

        [HttpPost]
        [Route("Plantillas/Instance")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Instance(int IdPlantilla)
        {
            var plantilla = await _context.Plantillas
                .Include(p => p.PlantillasPasosDetalle)
                    .ThenInclude(p => p.PasoNavigation)
                .Include(p => p.PlantillasPasosDetalle)
                    .ThenInclude(p => p.PlantillasPasosUsuariosDetalle)
                        .ThenInclude(p => p.AspNetUserNavigation)
                .Include(p => p.PlantillasCamposDetalle)
                    .ThenInclude(p => p.IdDatoTipoNavigation)
                .Include(p => p.PlantillasCamposDetalle)
                    .ThenInclude(p => p.PasosPlantillasCamposDetalle)
                .FirstOrDefaultAsync(m => m.IdPlantilla == IdPlantilla);
            if (plantilla == null)
            {
                return NotFound();
            }

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var steps = new List<InstanciasPlantillasPasosDetalle>();
            foreach (var templateStep in plantilla.PlantillasPasosDetalle)
            {
                var templateStepsUsers = new List<PasosUsuariosDetalle>();
                foreach (var usersInStep in templateStep.PlantillasPasosUsuariosDetalle)
                {
                    templateStepsUsers.Add(
                        new PasosUsuariosDetalle
                        {
                            AspNetUser = usersInStep.AspNetUser
                        }
                    );
                }
                steps.Add(
                    new InstanciasPlantillasPasosDetalle
                    {
                        AspNetUser = currentUserId,
                        PasosUsuariosDetalle = templateStepsUsers,
                        PasoNavigation = new PasosInstancias
                        {
                            Nombre = templateStep.PasoNavigation.Nombre,
                            Descripcion = templateStep.PasoNavigation.Descripcion,
                            FechaInicio = DateTime.Now,
                            IdLinkHelper = templateStep.Paso,
                            Numero = templateStep.PasoNavigation.Numero.GetValueOrDefault()
                        }
                    }
                );
            }

            var fields = new List<InstanciasPlantillasDatosDetalle>();
            foreach (var templateField in plantilla.PlantillasCamposDetalle)
            {
                fields.Add(
                    new InstanciasPlantillasDatosDetalle
                    {
                        NombreCampo = templateField.NombreCampo,
                        IdDatoTipo = templateField.IdDatoTipo,
                        IdLinkHelper = templateField.IdPlantillaCampo
                    }
                );
            }

            var instance = new InstanciasPlantillas
            {
                Nombre = $"{plantilla.Nombre}",
                Descripcion = plantilla.Descripcion,
                AspNetUser = currentUserId,
                Fecha = DateTime.Now,
                Estado = "Iniciada",
                Iniciada = "1",
                InstanciasPlantillasPasosDetalle = steps,
                InstanciasPlantillasDatosDetalle = fields,
            };

            _context.Add(instance);
            await _context.SaveChangesAsync();

            var instancedStepsAndFieldsLinks = new List<PasosInstanciasDatosDetalle>();
            foreach (var details in plantilla.PlantillasCamposDetalle)
            {
                foreach (var link in details.PasosPlantillasCamposDetalle)
                {
                    var instancedLink = new PasosInstanciasDatosDetalle
                    {
                        SoloLectura = link.SoloLectura,
                        InstanciaPlantillaDato =
                        instance.InstanciasPlantillasDatosDetalle
                        .Where(x => x.IdLinkHelper == link.PlantillaCampo)
                        .Select(x => x.IdInstanciaPlantillaDato)
                        .FirstOrDefault(),
                        Paso = instance.InstanciasPlantillasPasosDetalle
                        .Where(x => x.PasoNavigation.IdLinkHelper == link.Paso)
                        .Select(x => x.Paso)
                        .FirstOrDefault()
                    };
                    instancedStepsAndFieldsLinks.Add(instancedLink);
                }
            }

            _context.AddRange(instancedStepsAndFieldsLinks);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Plantilla instanciada exitosamente.";
            return RedirectToAction(nameof(InstanciasPlantillasController.Details), nameof(InstanciasPlantillas), new { id = instance.IdInstanciaPlantilla });
        }
    }
}
