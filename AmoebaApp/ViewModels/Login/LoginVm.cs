using System.ComponentModel.DataAnnotations;

namespace AmoebaApp.ViewModels.Login
{
    public class LoginVm
    {
        public string UsernamOrEmail { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
