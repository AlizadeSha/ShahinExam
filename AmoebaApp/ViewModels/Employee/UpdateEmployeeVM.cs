using System.ComponentModel.DataAnnotations;

namespace AmoebaApp.ViewModels.Employee
{
    public class UpdateEmployeeVM
    {
        [Required, MinLength(3)]
        public string Name { get; set; }
        [Required, MinLength(3), MaxLength(12)]

        public string Position { get; set; } //Mellim vezife menasinda yazmisam
        [Required, MaxLength(30)]
        public string Description { get; set; }
        public IFormFile? ImageUrl { get; set; }
        [Required]
        public string Twitter { get; set; }
        [Required]
        public string Facebook { get; set; }
        [Required]
        public string Instagram { get; set; }
        [Required]
        public string LinkedIn { get; set; }
    }
}
