# C# To-Do List Application

## Overview

This is a simple console-based To-Do List application written in C#. It allows users to manage their tasks through a command-line interface, providing functionality to add, view, and remove tasks.

## Features

- Add new tasks to the list
- View all current tasks
- Remove tasks from the list
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
2. Once the application starts, you will see a menu with the following options:
   - 1: Add Task
   - 2: View Tasks
   - 3: Remove Task
   - 4: Exit
3. Enter the number corresponding to the action you want to perform.
4. Follow the prompts to add, view, or remove tasks.
5. Select option 4 to exit the application.

## Code Structure

The application consists of a single C# file (`Program.cs`) containing the `ToDoListApp` class. This class includes the following methods:

- `Main()`: The entry point of the application.
- `ShowMenu()`: Displays the main menu and handles user input.
- `AddTask()`: Prompts the user to enter a new task and adds it to the list.
- `ViewTasks()`: Displays all current tasks in the list.
- `RemoveTask()`: Allows the user to remove a task by its number.

## Contributing

Feel free to fork this project and submit pull requests with any enhancements. You can also open issues for any bugs found or improvements you'd like to suggest.

## License

This project is open source and available under the [MIT License](https://opensource.org/licenses/MIT).
