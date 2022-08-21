namespace RedisPractice.Models
{
    public class GetScoreRequest : Player
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
