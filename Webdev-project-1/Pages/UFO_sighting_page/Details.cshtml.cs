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
    public class DetailsModel : PageModel
    {
        private readonly Webdev_project_1.Data.UFO_context _context;

        public DetailsModel(Webdev_project_1.Data.UFO_context context)
        {
            _context = context;
        }

      public UFO_sighting UFO_sighting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UFO_sightings == null)
            {
                return NotFound();
            }
            var ufo_sighting = await _context.UFO_sightings.Include(c => c.Category).FirstOrDefaultAsync(m => m.ID == id);
            if (ufo_sighting == null)
            {
                return NotFound();
            }
            else 
            {
                UFO_sighting = ufo_sighting;
            }
            return Page();
        }
    }
}
