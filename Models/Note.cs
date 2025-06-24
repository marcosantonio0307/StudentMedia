using System.ComponentModel.DataAnnotations;

namespace StudentMedia.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int PeriodId { get; set; }
        public Period Period { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int MatterId { get; set; }
        public Matter Matter { get; set; }

        [Required(ErrorMessage = "Score is required")]
        public float Score { get; set; }
    }
}