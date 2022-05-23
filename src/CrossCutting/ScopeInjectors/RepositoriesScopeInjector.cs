using Microsoft.Extensions.DependencyInjection;
using AM.Amil.PeNaAreia.Domain.Interfaces.Repositories;
using AM.Amil.PeNaAreia.Data.UnitOfWork;
using AM.Amil.PeNaAreia.Data.Repositories;

namespace AM.Amil.PeNaAreia.CrossCutting.InjetorEscopo
{
    public static class RepositoriesScopeInjector
    {
        public static void Add (IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IUsuarioProjetoRepository, UsuarioProjetoRepository>();
            services.AddScoped<IDoacaoProjetoRepository, DoacaoProjetoRepository>();
        }
    }
}
