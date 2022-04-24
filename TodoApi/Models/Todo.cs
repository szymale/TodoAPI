using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ExpiryTime { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Description { get; set; }
        public int Progress { get; set; } = 0;
        public bool IsFinished { get; set; } = false;
        public bool Overdue { get; set; } = false;
    }
}
