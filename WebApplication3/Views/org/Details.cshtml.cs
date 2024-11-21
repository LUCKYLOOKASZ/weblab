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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication3.Models.AppDbContext _context;

        public DetailsModel(WebApplication3.Models.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
