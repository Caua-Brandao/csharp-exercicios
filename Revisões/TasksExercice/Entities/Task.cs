
using TasksExercice.Entities.Enums;

namespace TasksExercice.Entities
{
    internal class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

        public Task(int id, string title, Priority priority)
        {
            this.Id = id;
            this.Title = title;
            this.Priority = priority;
            Status = Status.Pending;
        }

        public override string ToString()
        {
            return $"[{Id}] {Title} - {Priority} - {Status}";
        }
    }
}
