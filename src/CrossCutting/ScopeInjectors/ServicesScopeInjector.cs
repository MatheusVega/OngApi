using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AM.Amil.PeNaAreia.Domain.Interfaces.Services;
using AM.Amil.PeNaAreia.Business.Service;

namespace AM.Amil.PeNaAreia.CrossCutting.InjetorEscopo
{
    public static class ServicesScopeInjector
    {
        public static void Add(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProjetoService, ProjetoService>();
        }
        
    }
}
