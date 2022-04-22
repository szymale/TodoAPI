using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public DateTime ExpiryTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; }
        public bool IsFinished { get; set; }
        public bool Overdue { get; set; }
    }
}
