using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webdev_project_1.Data;
using Webdev_project_1.Models;

namespace Webdev_project_1.Pages.UFO_sighting_page
{
    public class EditModel : CategoryPageModel
    {
        private readonly Webdev_project_1.Data.UFO_context _context;

        public EditModel(Webdev_project_1.Data.UFO_context context)
        {
            _context = context;
        }

        [BindProperty]
        public UFO_sighting UFO_sighting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UFO_sightings == null)
            {
                return NotFound();
            }

            var ufo_sighting =  await _context.UFO_sightings.FirstOrDefaultAsync(m => m.ID == id);
            if (ufo_sighting == null)
            {
                return NotFound();
            }
            UFO_sighting = ufo_sighting;
            PopulateCategoryDropDownList(_context, ufo_sighting.CategoryID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
       public async Task<IActionResult> OnPostAsync(int? id)
       {
            if(id == null)
            {
                return NotFound();
            }

            var ufoToUpdate = await _context.UFO_sightings.FindAsync(id);

            if (ufoToUpdate == null) { return NotFound(); }

            if(await TryUpdateModelAsync<UFO_sighting>(
                ufoToUpdate,
                "UFO_sighting",
                s => s.ID, s => s.CategoryID, s => s.UFO_title, s => s.longitude, s => s.latitude, s => s.Observation_date, s => s.Description)) 
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateCategoryDropDownList(_context, ufoToUpdate.CategoryID);
            return Page();

       }

        private bool UFO_sightingExists(int id)
        {
          return _context.UFO_sightings.Any(e => e.ID == id);
        }
    }
}
