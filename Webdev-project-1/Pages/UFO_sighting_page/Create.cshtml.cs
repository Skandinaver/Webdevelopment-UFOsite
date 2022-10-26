using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webdev_project_1.Data;
using Webdev_project_1.Models;

namespace Webdev_project_1.Pages.UFO_sighting_page
{
    public class CreateModel : CategoryPageModel
    {
        private readonly Webdev_project_1.Data.UFO_context _context;

        public CreateModel(Webdev_project_1.Data.UFO_context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCategoryDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public UFO_sighting UFO_sighting { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyUFOSighting = new UFO_sighting();

            //THIS IS FOR DEBUGGING PURPOSES
            var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
  .SelectMany(E => E.Errors)
  .Select(E => E.ErrorMessage)
  .ToList();

            if (await TryUpdateModelAsync<UFO_sighting>(
                emptyUFOSighting,
                "UFO_sighting",
                s => s.ID, s => s.CategoryID,s => s.Category, s => s.UFO_title, s => s.longitude, s => s.latitude, s => s.Description, s => s.Observation_date))
            {
                _context.UFO_sightings.Add(emptyUFOSighting);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateCategoryDropDownList(_context, emptyUFOSighting.CategoryID);
            return Page();
        }
    }
}
