using Post_Service.Messaging;
using Post_Service.Contexts;
using Microsoft.EntityFrameworkCore;
using Post_Service.Controllers;
using Post_Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseInMemoryDatabase("PostsList"));

builder.Services.AddControllers();

builder.Services.AddSingleton<IMessageService, NatsService>();
builder.Services.AddSingleton<UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Load needed services
app.Services.GetServices<IMessageService>();
app.Services.GetService<UserService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();