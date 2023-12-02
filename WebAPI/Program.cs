using Application.Extensions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterServices();
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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("event", new OpenApiInfo { Title = "Event service of operational", Version = "v1" });
    c.SwaggerDoc("category", new OpenApiInfo { Title = "Category service of operational", Version = "v1" });
    c.SwaggerDoc("organizer", new OpenApiInfo { Title = "Organizer service of operational", Version = "v1" });
    c.SwaggerDoc("venue", new OpenApiInfo { Title = "Venue service of operational", Version = "v1" });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetValue<string>("ConnectionStrings:Database"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("category/swagger.json", "Category service of operational");
        c.SwaggerEndpoint("event/swagger.json", "Event service of operational");
        c.SwaggerEndpoint("organizer/swagger.json", "Organizer service of operational");
        c.SwaggerEndpoint("venue/swagger.json", "Venue service of operational");
    });
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
