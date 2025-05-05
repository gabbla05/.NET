using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Data musi być w przyszłości")]
        public DateTime Date { get; set; }

        public string? Description { get; set; }
    }
}
