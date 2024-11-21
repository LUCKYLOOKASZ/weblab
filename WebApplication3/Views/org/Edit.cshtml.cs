using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Views
{
    public class EditModel : PageModel
    {
        private readonly WebApplication3.Models.AppDbContext _context;

        public EditModel(WebApplication3.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrganizationEntity OrganizationEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationentity =  await _context.Organizations.FirstOrDefaultAsync(m => m.Id == id);
            if (organizationentity == null)
            {
                return NotFound();
            }
            OrganizationEntity = organizationentity;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrganizationEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationEntityExists(OrganizationEntity.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrganizationEntityExists(int id)
        {
            return _context.Organizations.Any(e => e.Id == id);
        }
    }
}
