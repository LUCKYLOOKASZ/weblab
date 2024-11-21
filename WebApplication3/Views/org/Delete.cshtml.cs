using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Views
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication3.Models.AppDbContext _context;

        public DeleteModel(WebApplication3.Models.AppDbContext context)
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

            var organizationentity = await _context.Organizations.FirstOrDefaultAsync(m => m.Id == id);

            if (organizationentity == null)
            {
                return NotFound();
            }
            else
            {
                OrganizationEntity = organizationentity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationentity = await _context.Organizations.FindAsync(id);
            if (organizationentity != null)
            {
                OrganizationEntity = organizationentity;
                _context.Organizations.Remove(OrganizationEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
