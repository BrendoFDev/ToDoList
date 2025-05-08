namespace ToDoList.Models
{
     /*
        UrgentAndImportant,
        UrgentButNotImportant,
        NotImportantAndUrgent,
        NotImportantAndNotUrgent
    */

    public class UrgencyLevel
    {

        public int Id { get; set; }
        public string description { get; set; }

    }
}
