using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce_Imovel.Data;
using E_Commerce_Imovel.Models;

namespace E_Commerce_Imovel.Controllers
{
    public class DomicilioController : Controller
    {
        private readonly AppDbContext _context;

        public DomicilioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Domicilio
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Domicilios.Include(d => d.Caracteristica);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Domicilio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilios
                .Include(d => d.Caracteristica)
                .FirstOrDefaultAsync(m => m.DomicilioId == id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return View(domicilio);
        }

        // GET: Domicilio/Create
        public IActionResult Create()
        {
            ViewData["CaracteristicaId"] = new SelectList(_context.Caracteristicas, "CaracteristicaId", "CaracteristicaId");
            return View();
        }

        // POST: Domicilio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DomicilioId,CaracteristicaId,Preco,Sobre,Publicacao,Estado,Cidade")] Domicilio domicilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(domicilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaracteristicaId"] = new SelectList(_context.Caracteristicas, "CaracteristicaId", "CaracteristicaId", domicilio.CaracteristicaId);
            return View(domicilio);
        }

        // GET: Domicilio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilios.FindAsync(id);
            if (domicilio == null)
            {
                return NotFound();
            }
            ViewData["CaracteristicaId"] = new SelectList(_context.Caracteristicas, "CaracteristicaId", "CaracteristicaId", domicilio.CaracteristicaId);
            return View(domicilio);
        }

        // POST: Domicilio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DomicilioId,CaracteristicaId,Preco,Sobre,Publicacao,Estado,Cidade")] Domicilio domicilio)
        {
            if (id != domicilio.DomicilioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(domicilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomicilioExists(domicilio.DomicilioId))
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
            ViewData["CaracteristicaId"] = new SelectList(_context.Caracteristicas, "CaracteristicaId", "CaracteristicaId", domicilio.CaracteristicaId);
            return View(domicilio);
        }

        // GET: Domicilio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilios
                .Include(d => d.Caracteristica)
                .FirstOrDefaultAsync(m => m.DomicilioId == id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return View(domicilio);
        }

        // POST: Domicilio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var domicilio = await _context.Domicilios.FindAsync(id);
            if (domicilio != null)
            {
                _context.Domicilios.Remove(domicilio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DomicilioExists(int id)
        {
            return _context.Domicilios.Any(e => e.DomicilioId == id);
        }
    }
}
