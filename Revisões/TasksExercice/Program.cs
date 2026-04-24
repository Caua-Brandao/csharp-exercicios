using System;
using TasksExercice.Entities;
using TasksExercice.Entities.Enums;

namespace TasksExercice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            manager.AddTask("STUDYING C#", Priority.High);
            manager.AddTask("MAKE EXERCICE", Priority.Urgent);
            manager.AddTask("READING A BOOK", Priority.Low);

            Console.WriteLine("\n=== ALL TASKS ===");
            manager.ListAll();

            Console.WriteLine("\n=== URGENT TASKS ===");
            manager.FindByPriority(Priority.Urgent);

            Console.WriteLine("\n=== REMOVING TASK 2 ===");
            manager.RemoveTask(2);

            Console.WriteLine("\n=== TASKS AFTER REMOVAL");
            manager.ListAll();
        }
    }
}
