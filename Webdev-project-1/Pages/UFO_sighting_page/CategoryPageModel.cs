using Webdev_project_1.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Webdev_project_1.Pages.UFO_sighting_page
{
    public class CategoryPageModel : PageModel
    {
        public SelectList CategoryNameSL { get; set; }

        public void PopulateCategoryDropDownList(UFO_context _context,
            object selectedCategory = null)
        {
            var categoryQuery = from c in _context.Categories
                                orderby c.ID
                                select c;
            CategoryNameSL = new SelectList(categoryQuery.AsNoTracking(),
                "ID", "Category_name", selectedCategory);
        }
    }
}
