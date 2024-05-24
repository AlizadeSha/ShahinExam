using System.ComponentModel.DataAnnotations;

namespace AmoebaApp.ViewModels.Register
{
    public class RegisterVm
    {
        [Required]
        public string  Name { get; set; }
        [Required]

        public string  Surname { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        
        public string Email { get; set; }
        [Required]

        public string  Username { get; set; }
        [Required,DataType(DataType.Password)]

        public string Password { get; set; }


    }
}
