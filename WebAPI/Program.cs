using Application.Services;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IGenericRepositoryAsync<Event>, GenericRepositoryBaseAsync<Event, ApplicationDbContext>>();

builder.Services.AddScoped<ISeatedEventService, SeatedEventService>();
builder.Services.AddScoped<IGenericRepositoryAsync<SeatedEvent>, GenericRepositoryBaseAsync<SeatedEvent, ApplicationDbContext>>();

builder.Services.AddScoped<IStandingEventService, StandingEventService>();
builder.Services.AddScoped<IGenericRepositoryAsync<StandingEvent>, GenericRepositoryBaseAsync<StandingEvent, ApplicationDbContext>>();

builder.Services.AddScoped<IEventImageService, EventImageService>();
builder.Services.AddScoped<IGenericRepositoryAsync<EventImage>, GenericRepositoryBaseAsync<EventImage, ApplicationDbContext>>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.SetIsOriginAllowed((host) => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
