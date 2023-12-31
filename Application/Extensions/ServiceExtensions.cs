﻿using Application.Services;
using Domain.Entities;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Shared.Repository;

namespace Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IGenericRepositoryAsync<Event>, GenericRepositoryBaseAsync<Event, ApplicationDbContext>>();

            services.AddScoped<ISeatedEventService, SeatedEventService>();
            services.AddScoped<IGenericRepositoryAsync<SeatedEvent>, GenericRepositoryBaseAsync<SeatedEvent, ApplicationDbContext>>();

            services.AddScoped<IStandingEventService, StandingEventService>();
            services.AddScoped<IGenericRepositoryAsync<StandingEvent>, GenericRepositoryBaseAsync<StandingEvent, ApplicationDbContext>>();

            services.AddScoped<IEventImageService, EventImageService>();
            services.AddScoped<IGenericRepositoryAsync<EventImage>, GenericRepositoryBaseAsync<EventImage, ApplicationDbContext>>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGenericRepositoryAsync<Category>, GenericRepositoryBaseAsync<Category, ApplicationDbContext>>();

            services.AddScoped<IOrganiserService, OrganiserService>();
            services.AddScoped<IGenericRepositoryAsync<Organiser>, GenericRepositoryBaseAsync<Organiser, ApplicationDbContext>>();

            services.AddScoped<IVenueService, VenueService>();
            services.AddScoped<IGenericRepositoryAsync<Venue>, GenericRepositoryBaseAsync<Venue, ApplicationDbContext>>();
        }
    }
}
