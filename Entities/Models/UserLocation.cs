using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table ("UserLocations")]
    public class UserLocation
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [MaxLength(100, ErrorMessage ="Name cannot be longer than 100 characters")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100, ErrorMessage = "Latitude is required")]
        public string latitude { get; set; } = string.Empty;

        [Required]
        [MaxLength(100, ErrorMessage = "Longitude is required")]
        public string longitude { get; set; } = string.Empty;
    }
}
