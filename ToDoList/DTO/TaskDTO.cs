namespace ToDoList.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TaskStatusId { get; set; }
        public int UrgencyLevelId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
