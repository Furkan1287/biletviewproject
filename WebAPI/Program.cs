using Application.Services;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISeatedEventService, SeatedEventService>();
builder.Services.AddScoped<IStandingEventService, StandingEventService>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddScoped<IGenericRepositoryAsync<SeatedEvent>, GenericRepositoryBaseAsync<SeatedEvent, ApplicationDbContext>>();
builder.Services.AddScoped<IGenericRepositoryAsync<StandingEvent>, GenericRepositoryBaseAsync<StandingEvent, ApplicationDbContext>>();
builder.Services.AddScoped<IGenericRepositoryAsync<Event>, GenericRepositoryBaseAsync<Event, ApplicationDbContext>>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetValue<string>("ConnectionStrings:Database"));
});

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
