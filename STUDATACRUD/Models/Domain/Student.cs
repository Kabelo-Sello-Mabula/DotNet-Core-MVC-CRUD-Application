using System.ComponentModel.DataAnnotations;

namespace STUDATACRUD.Models.Domain
{
    public class Student
    {
        
        public Guid id { get; set; }

        [Required]
        [MaxLength(9)]
        public string studentNumber { get; set; }
        [MaxLength(20)]
        public string firstname { get; set; }
        [MaxLength(9)]
        public string  surname { get; set; }
        public DateTime DateOfBirth { get; set; }



    }
}
