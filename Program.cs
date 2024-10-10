using System.Text.Json;
using System.Text.Json.Serialization;

class Task
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    [JsonConstructor]
    public Task(string description, bool isCompleted = false)
    {
        Description = description;
        IsCompleted = isCompleted;
    }
}

class ToDoListApp
{
    static List<Task> tasks = new List<Task>();
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
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Remove Task");
            Console.WriteLine("5. Save and Exit");

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
                    CompleteTask();
                    break;
                case "4":
                    RemoveTask();
                    break;
                case "5":
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
        string? description = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(description))
        {
            tasks.Add(new Task(description));
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
                Console.WriteLine($"{i + 1}. [{(tasks[i].IsCompleted ? "X" : " ")}] {tasks[i].Description}");
            }
        }
    }

    static void CompleteTask()
    {
        ViewTasks();
        if (tasks.Count == 0) return;

        Console.WriteLine("Enter the task number to mark as completed:");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int taskNumber) && taskNumber <= tasks.Count && taskNumber > 0)
        {
            int index = taskNumber - 1;
            if (!tasks[index].IsCompleted)
            {
                tasks[index].IsCompleted = true;
                Console.WriteLine("Task marked as completed!");
            }
            else
            {
                Console.WriteLine("This task is already completed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid task number.");
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
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(FILE_NAME, jsonString);
    }

    static void LoadTasks()
    {
        if (File.Exists(FILE_NAME))
        {
            string jsonString = File.ReadAllText(FILE_NAME);
            try
            {
                tasks = JsonSerializer.Deserialize<List<Task>>(jsonString) ?? new List<Task>();
            }
            catch (JsonException)
            {
                // If deserialization as List<Task> fails, try deserializing as List<string>
                try
                {
                    var oldTasks = JsonSerializer.Deserialize<List<string>>(jsonString);
                    if (oldTasks != null)
                    {
                        tasks = oldTasks.ConvertAll(description => new Task(description));
                        Console.WriteLine("Converted old task format to new format.");
                    }
                }
                catch (JsonException)
                {
                    Console.WriteLine("Error loading tasks. Starting with an empty list.");
                    tasks = new List<Task>();
                }
            }
        }
    }
}
