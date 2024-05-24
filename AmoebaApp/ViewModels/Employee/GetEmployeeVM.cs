using System.ComponentModel.DataAnnotations;

namespace AmoebaApp.ViewModels.Employee
{
    public class GetEmployeeVM
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; } //Mellim vezife menasinda yazmisam
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
    }
}
