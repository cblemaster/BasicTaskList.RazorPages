# BasicTaskList.RazorPages

## An application that provides basic task list functionality

### Built with:
- .NET 7 / C# 11
- SQL Server database
- ASP.NET Core Web App (Razor Pages) project
- Entity Framework Core 7

### Features:
- See a list of folders that contain tasks, and the count of tasks in each folder
- See the tasks that are in a folder
- Filter the list of tasks to only those that are incomplete
- See the details of a task
- Add a new (empty) folder
- Rename a folder
- Delete a folder (along with its contents)
- Add a new task to a folder
- Make changes to a task's details, including changing a task's folder
- Save changes to a task's details
- Cancel changes to a task's details
- Delete a task from a folder
- See all tasks that are important
- See all tasks that are due today
- See all tasks that are complete

### Business rules:
- Folder name is required and must be 255 characters or less
- Task name is required and must be 255 characters or less
- Task description is optional and must be 255 characters or less

### UI Conventions:
- Folders shown in a list are always sorted by Name
- Tasks shown in a list are always sorted by Due Date, then by Name

### Instructions for running the application:
- Instructions for creating the database from the provided script: TBD
- Clone the repo, run the solution

### Improvement Opportunities:
- TBD

