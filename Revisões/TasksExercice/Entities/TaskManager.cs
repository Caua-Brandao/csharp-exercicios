using System;
using System.Collections.Generic;
using System.Linq;
using TasksExercice.Entities.Enums;

namespace TasksExercice.Entities
{
    internal class TaskManager
    {
        private List<Task> tasks;
        private int nextId;

        public TaskManager()
        {
            tasks = new List<Task>();
            nextId = 1;
        }

        public void AddTask(string title, Priority priority)
        {
            Task task = new Task(nextId, title, priority);
            tasks.Add(task);
            Console.WriteLine($"Task {title} added (ID: {nextId})");
            nextId++;
        }

        public void ListAll()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to display");
            }
            else
            {
                foreach (Task task in tasks)
                {
                    Console.WriteLine(task);
                }
            }
        }

        public void RemoveTask(int id)
        {
            Task task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                Console.WriteLine($"Task {id} removed successfully");
            }
            else
            {
                Console.WriteLine("There is not a task with this Id");
            }
        }

        public void FindByPriority(Priority priority)
        {
            List<Task> FoundTasks = tasks.FindAll(t => t.Priority == priority);
            if (FoundTasks.Count() > 0)
            {
                foreach(Task task in FoundTasks)
                {
                    Console.WriteLine($"ID: {task.Id}, Title: {task.Title}");
                }
            }
        }
    }
}
