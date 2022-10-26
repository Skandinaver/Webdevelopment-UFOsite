using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Webdev_project_1.Data;
using Webdev_project_1.Models;

namespace Webdev_project_1.Pages.UFO_sighting_page
{
    public class IndexModel : PageModel
    {
        private readonly Webdev_project_1.Data.UFO_context _context;

        public IndexModel(Webdev_project_1.Data.UFO_context context)
        {
            _context = context;
        }

        public IList<UFO_sighting> UFO_sighting { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UFO_sightings != null)
            {
                UFO_sighting = await _context.UFO_sightings
                .Include(u => u.Category).ToListAsync();
            }
        }
    }
}
