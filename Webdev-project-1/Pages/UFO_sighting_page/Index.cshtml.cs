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
    public class IndexModel : PageModel
    {
        private readonly Webdev_project_1.Data.UFO_context _context;

        public IndexModel(Webdev_project_1.Data.UFO_context context)
        {
            _context = context;
        }

        public IList<UFO_sighting> UFO_sighting { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList ? Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? UFOCategory { get; set; }
        public async Task OnGetAsync()
        {
            var UFO_sightings = from m in _context.UFO_sightings
                       select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                UFO_sightings = UFO_sightings.Where(s => s.UFO_title.Contains(SearchString));
            }
            UFO_sighting = await UFO_sightings
            .Include(u => u.Category).ToListAsync();
        }
    }
}
