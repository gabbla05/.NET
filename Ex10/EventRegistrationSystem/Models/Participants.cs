using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int EventId { get; set; }
    }
}
