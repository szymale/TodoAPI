namespace TodoApi.Dtos
{
    public class TodoReadDto
    {
        public int Id { get; set; }
        public DateTime ExpiryTime { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Progress { get; set; } = 0;
        public bool IsFinished { get; set; } = false;
        public bool Overdue { get; set; } = false;
    }
}
