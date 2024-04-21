using System;
using System.Collections.Generic;

namespace TodoList
{
        class Task
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string description)
        {
            Description = description;
            IsCompleted = false;
        }
    }

        class Program
    {

        static List<Task> tasks = new List<Task>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the To-Do List Application!");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. View tasks");
                Console.WriteLine("3. Edit a task");
                Console.WriteLine("4. Prioritize a task");
                Console.WriteLine("5. Delete a task");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewTasks();
                        break;
                    case "3":
                        EditTask();
                        break;
                    case "4":
                        PrioritizeTask();
                        break;
                    case "5":
                        DeleteTask();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.Write("Enter the task: ");
            string taskDescription = Console.ReadLine();
            tasks.Add(new Task(taskDescription));
            Console.WriteLine("Task added successfully!");
        }

        static void ViewTasks()
        {
            Console.WriteLine("\nTasks:");
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks added yet.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {(tasks[i].IsCompleted ? "[Completed] " : "")}{tasks[i].Description}");
                }
            }
        }

        static void EditTask()
        {
            ViewTasks();
            Console.Write("Enter the number of the task you want to edit: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < tasks.Count)
            {
                Console.Write("Enter the new task description: ");
                tasks[index].Description = Console.ReadLine();
                Console.WriteLine("Task edited successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        static void PrioritizeTask()
        {
            ViewTasks();
            Console.Write("Enter the number of the task you want to prioritize: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < tasks.Count)
            {
                Task task = tasks[index];
                tasks.RemoveAt(index);
                tasks.Insert(0, task);
                Console.WriteLine("Task prioritized successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        static void DeleteTask()
        {
            ViewTasks();
            Console.Write("Enter the number of the task you want to delete: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
    } 
}
