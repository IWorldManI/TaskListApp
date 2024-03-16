$scriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Definition
$projectPath = Join-Path -Path $scriptRoot -ChildPath "..\..\..\TaskListApp\TaskListApp.Database"

cd $projectPath

dotnet ef migrations add InitialCreate --context ApplicationDbContext --startup-project $projectPath --project $projectPath --output-dir "$projectPath\Migrations" -v