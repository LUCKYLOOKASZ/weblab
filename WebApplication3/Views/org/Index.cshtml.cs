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
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Models.AppDbContext _context;

        public IndexModel(WebApplication3.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<OrganizationEntity> OrganizationEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrganizationEntity = await _context.Organizations.ToListAsync();
        }
    }
}
