using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Exceptions;
using UMS.Infrastructure.Abstraction.MailServices;
using UMS.Persistence;
using Serilog.Sinks.Elasticsearch;
using UMS.Domain.Models;
using UMS.Infrastructure.Abstraction.ChatHub;
using UMS.Infrastructure.Services;
using UMSWebAPI.Behaviors;
using UMSWebAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UmsContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=ums;Username=postgres;Password=123456"));
builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("UMS.Application"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailServicess, MailServicess>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TimerBehavior<,>));
builder.Services.AddTransient<IChatHub, ChatHub>();
builder.Services.AddSignalR();

builder.ConfigureLogging();

var app = builder.Build();

app.MapHub<ChatHub>("/chatHub");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.RegisterTimingMiddleware();

app.Run();