using System.ComponentModel.DataAnnotations;

namespace StudentMedia.Models
{
    public class Matter
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}