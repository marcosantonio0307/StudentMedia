using System.ComponentModel.DataAnnotations;

namespace StudentMedia.Models
{
    public class Period
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Notes Amount is required")]
        public int NotesAmount { get; set; }
    }
}
