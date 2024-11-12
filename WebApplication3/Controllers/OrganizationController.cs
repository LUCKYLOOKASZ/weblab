using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly AppDbContext _context;

        public OrganizationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Organization
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Type.Include(c => c.Organization);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Organization/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEntity = await _context.Type
                .Include(c => c.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactEntity == null)
            {
                return NotFound();
            }

            return View(contactEntity);
        }

        // GET: Organization/Create
        public IActionResult Create()
        {
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id");
            return View();
        }

        // POST: Organization/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email,PhoneNumber,BirthDate,Category,Created,OrganizationId")] ContactEntity contactEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", contactEntity.OrganizationId);
            return View(contactEntity);
        }

        // GET: Organization/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEntity = await _context.Type.FindAsync(id);
            if (contactEntity == null)
            {
                return NotFound();
            }
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", contactEntity.OrganizationId);
            return View(contactEntity);
        }

        // POST: Organization/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Email,PhoneNumber,BirthDate,Category,Created,OrganizationId")] ContactEntity contactEntity)
        {
            if (id != contactEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactEntityExists(contactEntity.Id))
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
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", contactEntity.OrganizationId);
            return View(contactEntity);
        }

        // GET: Organization/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactEntity = await _context.Type
                .Include(c => c.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactEntity == null)
            {
                return NotFound();
            }

            return View(contactEntity);
        }

        // POST: Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactEntity = await _context.Type.FindAsync(id);
            if (contactEntity != null)
            {
                _context.Type.Remove(contactEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactEntityExists(int id)
        {
            return _context.Type.Any(e => e.Id == id);
        }
    }
}
