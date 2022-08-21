using System.ComponentModel.DataAnnotations;

namespace RedisPractice.Models
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? PlayerName { get; set; }
    }
}
