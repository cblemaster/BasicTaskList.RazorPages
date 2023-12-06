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
- Delete a folder (along with its tasks)
- Add a new task to a folder
- Make changes to a task's details, including changing the task's folder
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
- Clone or download the repo
- Set up the SQL Server database
	- Go to \BasicTaskList.RazorPages\BasicTaskList.RazorPages\Data\Database
	- There are two (2) script files here:
		- basictasklist-create-db-script.sql: running this script is required and it will create the database and tables
		- basictasklist-load-sample-data-script.sql: running this script is optional and it will insert some sample folder and task data into the database
- Connection string
	- In appsettings.json, update the "Project" connection string to point to your database
	- Run the solution

### Improvement Opportunities:
- See TODOs in the source code
- Upgrade to .NET 8
- Add Identity and allow different users to have different folders