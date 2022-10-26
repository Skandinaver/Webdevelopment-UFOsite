using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Webdev_project_1.Data;

namespace Webdev_project_1.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new UFO_context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<UFO_context>>()))
            {
                if (context == null || context.Categories == null)
                {
                    throw new ArgumentNullException("Null UFO_context");
                }
                //Look for categories
                if(context.Categories.Any())
                {
                    return; // Database already seeded
                }

                context.Categories.AddRange(
                    new Category
                    {
                        Category_name = "Close Encounter of the First Kind"
                    },
                    new Category
                    {
                        Category_name = "Close Encounter of the Second Kind"
                    },
                    new Category
                    {
                        Category_name = "Close Encounter of the Third Kind"
                    },
                    new Category
                    {
                        Category_name = "Close Encounter of the Fourth Kind"
                    },
                    new Category
                    {
                        Category_name = "Close Encounter of the Fifth Kind"
                    }
                    );
                context.SaveChanges();
            }
        }

    }
}
