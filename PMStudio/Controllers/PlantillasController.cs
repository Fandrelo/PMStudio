using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMStudio.Areas.Identity.Data;
using PMStudio.Models;
using PMStudio.Models.Entities;

namespace PMStudio.Controllers
{
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
            SetupCreateViewBag();
            return View(model);
        }

        [HttpPost]
        [Route("Plantillas/AddStep")]
        public IActionResult AddStep(Plantillas plantilla)
        {
            plantilla.PlantillasPasosDetalle
                .Add(new PlantillasPasosDetalle() { PlantillasPasosUsuariosDetalle = new List<PlantillasPasosUsuariosDetalle>() });
            SetupCreateViewBag();
            return View(nameof(Create), plantilla);
        }

        [HttpPost]
        [Route("Plantillas/AddField")]
        public IActionResult AddField(Plantillas plantilla)
        {
            plantilla.PlantillasCamposDetalle
                .Add(new PlantillasCamposDetalle());
            SetupCreateViewBag();
            return View(nameof(Create), plantilla);
        }

        [HttpPost]
        [Route("Plantillas/AddUser/{step}")]
        public IActionResult AddUser(Plantillas plantilla, int step)
        {
            plantilla.PlantillasPasosDetalle[step].PlantillasPasosUsuariosDetalle.Add(new PlantillasPasosUsuariosDetalle());
            SetupCreateViewBag();
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
                await _context.SaveChangesAsync();
                TempData["Success"] = "Plantilla creada exitosamente";
                return RedirectToAction(nameof(Index));
            }
            SetupCreateViewBag();
            return View(plantillas);
        }

        private void SetupCreateViewBag()
        {
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
    }
}
