namespace ToDoList2.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
