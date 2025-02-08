using System.ComponentModel.DataAnnotations;

namespace STUDATACRUD.Models
{
    public class UpdateStudentViewModel
    {

        public Guid id { get; set; }
        public string studentNumber { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
