using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos
{
    public class TodoCreateDto
    {
        [Required]
        public DateTime ExpiryTime { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public int Progress { get; set; } = 0;
    }
}
