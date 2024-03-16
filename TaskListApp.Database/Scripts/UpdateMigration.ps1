$scriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Definition
$projectPath = Join-Path -Path $scriptRoot -ChildPath "..\..\..\TaskListApp\TaskListApp.Database"

$context = "ApplicationDbContext"

cd $projectPath

dotnet ef database update --context $context