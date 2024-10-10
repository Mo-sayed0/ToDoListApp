using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class ToDoListApp
{
    static List<string> tasks = new List<string>();
    const string FILE_NAME = "tasks.json";

    static void Main(string[] args)
    {
        LoadTasks();
        ShowMenu();
        SaveTasks();
    }
    
    static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nTo-Do List Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. Save and Exit");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    RemoveTask();
                    break;
                case "4":
                    SaveTasks();
                    Console.WriteLine("Tasks saved. Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.WriteLine("Enter the task:");
        string? task = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(task))
        {
            tasks.Add(task);
            Console.WriteLine("Task added successfully!");
        }
        else
        {
            Console.WriteLine("Task cannot be empty. Please try again.");
        }
    }

    static void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Your task list is empty.");
        }
        else
        {
            Console.WriteLine("Your tasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    static void RemoveTask()
    {
        ViewTasks();
        if (tasks.Count == 0) return;

        Console.WriteLine("Enter the task number to remove:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int taskNumber) && taskNumber <= tasks.Count && taskNumber > 0)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Task removed successfully!");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    static void SaveTasks()
    {
        string jsonString = JsonSerializer.Serialize(tasks);
        File.WriteAllText(FILE_NAME, jsonString);
    }

    static void LoadTasks()
    {
        if (File.Exists(FILE_NAME))
        {
            string jsonString = File.ReadAllText(FILE_NAME);
            tasks = JsonSerializer.Deserialize<List<string>>(jsonString) ?? new List<string>();
        }
    }
}