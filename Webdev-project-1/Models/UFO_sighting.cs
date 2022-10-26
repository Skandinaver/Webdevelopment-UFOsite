using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Webdev_project_1.Models
{
    public class UFO_sighting
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public string? UFO_title { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public  decimal longitude { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal latitude { get; set; }

        [DataType(DataType.Date)]
        public DateTime Observation_date { get; set; }
        public string? Description { get; set; }

    }
}
