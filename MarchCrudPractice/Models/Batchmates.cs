using System.ComponentModel.DataAnnotations;

namespace MarchCrudPractice.Models
{
    public class Batchmates
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; }
    }
}