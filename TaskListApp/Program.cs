using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskListApp.Commands.UserCommands;
using TaskListApp.Database.DBConnector;
using TaskListApp.Services.AuthentificationService;
using TaskListApp.Services.CommentService;
using TaskListApp.Services.TaskListService;
using TaskListApp.Services.TaskService;
using TaskListApp.Services.UserService;
using TaskListApp.Services.ValidationService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    }); 
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TaskListApp",
        Version = "v1",
        Description = "The project is a simple application for managing notes. Implemented using CQRS with MediatR and FluentValidator for data validation.",
        Contact = new OpenApiContact
        {
            Name = "Rudenko Roman",
            Email = "rudenko.r.i15@gmail.com",
            Url = new Uri("https://github.com/IWorldManI"),
        },
    });

});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Program)));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<ITaskListService, TaskListService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IValidationService, ValidationService>();
builder.Services.AddTransient<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();
builder.Services.AddSingleton<AuthenticationService>();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
