# C# To-Do List Application

## Overview

This is a console-based To-Do List application written in C#. It allows users to manage their tasks through a command-line interface, providing functionality to add, view, complete, and remove tasks. The application includes persistence, saving tasks to a file so they can be retrieved in future sessions.

## Features

- Add new tasks to the list
- View all current tasks with their completion status
- Mark tasks as completed
- Remove tasks from the list
- Save tasks to a file for persistence between sessions
- Load previously saved tasks when the application starts
- Simple and intuitive console-based user interface

## Prerequisites

To run this application, you need to have the following installed on your system:

- .NET SDK (version 5.0 or later recommended)
- A C# compatible IDE (Visual Studio, Visual Studio Code with C# extension, or JetBrains Rider)

## Setup

1. Clone this repository or download the source code.
2. Open the project in your preferred C# IDE.
3. Build the project to restore any necessary packages.

## Usage

1. Run the application from your IDE or use the following command in the terminal:
   ```
   dotnet run
   ```
2. Once the application starts, it will load any previously saved tasks.
3. You will see a menu with the following options:
   - 1: Add Task
   - 2: View Tasks
   - 3: Complete Task
   - 4: Remove Task
   - 5: Save and Exit
4. Enter the number corresponding to the action you want to perform.
5. Follow the prompts to add, view, complete, or remove tasks.
6. Select option 5 to save your tasks and exit the application.

## Code Structure

The application consists of a single C# file (`Program.cs`) containing two classes:

1. `Task` class:

   - Represents a single task with a description and completion status.

2. `ToDoListApp` class, which includes the following methods:
   - `Main()`: The entry point of the application.
   - `ShowMenu()`: Displays the main menu and handles user input.
   - `AddTask()`: Prompts the user to enter a new task and adds it to the list.
   - `ViewTasks()`: Displays all current tasks in the list with their completion status.
   - `CompleteTask()`: Allows the user to mark a task as completed.
   - `RemoveTask()`: Allows the user to remove a task by its number.
   - `SaveTasks()`: Serializes the task list to JSON and saves it to a file.
   - `LoadTasks()`: Loads tasks from the JSON file when the application starts.

## File Storage

Tasks are stored in a file named `tasks.json` in the same directory as the application. This file is automatically created when you first save tasks and is read when the application starts.

## Contributing

Feel free to fork this project and submit pull requests with any enhancements. You can also open issues for any bugs found or improvements you'd like to suggest.
