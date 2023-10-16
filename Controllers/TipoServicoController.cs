using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Petshop.Models;

namespace Petshop.Controllers
{
    public class TipoServicoController : Controller
    {
        private readonly Contexto _context;

        public TipoServicoController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoServico
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoServicos.ToListAsync());
        }

        // GET: TipoServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoServicos == null)
            {
                return NotFound();
            }

            var tipoServico = await _context.TipoServicos
                .FirstOrDefaultAsync(m => m.idTipoServico == id);
            if (tipoServico == null)
            {
                return NotFound();
            }

            return View(tipoServico);
        }

        // GET: TipoServico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoServico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTipoServico,descricao")] TipoServico tipoServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoServico);
        }

        // GET: TipoServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoServicos == null)
            {
                return NotFound();
            }

            var tipoServico = await _context.TipoServicos.FindAsync(id);
            if (tipoServico == null)
            {
                return NotFound();
            }
            return View(tipoServico);
        }

        // POST: TipoServico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTipoServico,descricao")] TipoServico tipoServico)
        {
            if (id != tipoServico.idTipoServico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoServicoExists(tipoServico.idTipoServico))
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
            return View(tipoServico);
        }

        // GET: TipoServico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoServicos == null)
            {
                return NotFound();
            }

            var tipoServico = await _context.TipoServicos
                .FirstOrDefaultAsync(m => m.idTipoServico == id);
            if (tipoServico == null)
            {
                return NotFound();
            }

            return View(tipoServico);
        }

        // POST: TipoServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoServicos == null)
            {
                return Problem("Entity set 'Contexto.TipoServicos'  is null.");
            }
            var tipoServico = await _context.TipoServicos.FindAsync(id);
            if (tipoServico != null)
            {
                _context.TipoServicos.Remove(tipoServico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoServicoExists(int id)
        {
          return _context.TipoServicos.Any(e => e.idTipoServico == id);
        }
    }
}
