using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webdev_project_1.Models;

namespace Webdev_project_1.Data
{
    public class UFO_context : DbContext
    {
        public UFO_context (DbContextOptions<UFO_context> options)
            : base(options)
        {

        }

        public DbSet<Webdev_project_1.Models.UFO_sighting> UFO_sightings { get; set; } = default!;
        public DbSet<Webdev_project_1.Models.Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<UFO_sighting>().ToTable("UFO_sighting");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
