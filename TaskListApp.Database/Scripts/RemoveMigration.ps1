$StartupProjectPath = "C:\Users\mmari\source\repos\TaskListApp\TaskListApp.Database"
$Context = "ApplicationDbContext"

cd $StartupProjectPath

dotnet ef migrations remove --context $Context