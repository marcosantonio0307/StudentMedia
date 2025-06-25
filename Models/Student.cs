using System.ComponentModel.DataAnnotations;

namespace StudentMedia.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Document is required")]
        public string Document { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
