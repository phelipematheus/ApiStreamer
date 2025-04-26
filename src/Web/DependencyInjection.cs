using Domain.Interfaces.Repositories;
using Infrastructure.Repositories.Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Conteudo;
using Service.Criador;
using Service.Interfaces;
using Service.Playlist;
using Service.Services;
using Service.Usuario;
using Web.Middlewares;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddSingleton<ErrorHandling>();
        services.AddSingleton<LoggingMiddleware>();

        services.AddScoped<IPlaylistService, PlaylistService>();
        services.AddScoped<IPlaylistRepository, PlaylistRepository>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<ICriadorRepository, CriadorRepository>();
        services.AddScoped<ICriadorService, CriadorService>();
        services.AddScoped<IConteudoService, ConteudoService>();
        services.AddScoped<IConteudoRepository, ConteudoRepository>();
        services.AddScoped<IItemPlaylistService, ItemPlaylistService>();
        services.AddScoped<IItemPlaylistRepository, ItemPlaylistRepository>();

        services.AddHttpContextAccessor();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddEndpointsApiExplorer();

        return services;
    }
}
