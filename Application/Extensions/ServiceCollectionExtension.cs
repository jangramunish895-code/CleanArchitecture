using Application.Interfaces.Respositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediator();
        services.AddService();
    }

    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(x=>x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
    public static void AddService(this IServiceCollection services)
    {
        services.AddTransient<IMediator, Mediator>();
    }
}
