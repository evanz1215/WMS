﻿using Application.Common.Dependencies.DataAccess;
using Application.Common.Dependencies.DataAccess.Repositories;
using Application.Common.Dependencies.Services;
using Infrastructure.ApplicationDependencies.DataAccess;
using Infrastructure.ApplicationDependencies.DataAccess.Repositories;
using Infrastructure.ApplicationDependencies.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ApplicationDependencies
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IDateTime, DateTimeService>();
            //services.AddTransient<IStockStatisticsService, StockStatisticsService>();
        }
    }
}