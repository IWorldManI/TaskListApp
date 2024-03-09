$context = "ApplicationDbContext"

dotnet ef migrations add AddFieldToTaskItem --context $context --startup-project C:\Users\mmari\source\repos\TaskListApp\TaskListApp.Database --project C:\Users\mmari\source\repos\TaskListApp\TaskListApp.Database --output-dir C:\Users\mmari\source\repos\TaskListApp\TaskListApp.Database\Migrations -v