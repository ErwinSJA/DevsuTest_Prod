using WebAPI.DevsuTest.Setup;
using WebAPI.DevsuTest.Commons.CapaActual;
using WebAPI.DevsuTest.Commons.DapperHelper;
using WebAPI.DevsuTest.Interfaces.Services;
using WebAPI.DevsuTest.Services.Services;
using WebAPI.DevsuTest.Interfaces.Repositories;
using WebAPI.DevsuTest.Repositories.Repositories;

WebApplication app = DefaultDistribtWebAPI.Create(args, webappBuilder =>
{
    webappBuilder.Services.AddTransient<IDapperHelper, DapperHelper>();
    webappBuilder.Services.AddTransient<ICapaActualService, CapaActualService>();

    webappBuilder.Services.AddScoped<IPersonaService, PersonaService>();
    webappBuilder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
    webappBuilder.Services.AddScoped<IClienteService, ClienteService>();
    webappBuilder.Services.AddScoped<IClienteRepository, ClienteRepository>();
    webappBuilder.Services.AddScoped<ICuentaService, CuentaService>();
    webappBuilder.Services.AddScoped<ICuentaRepository, CuentaRepository>();
    webappBuilder.Services.AddScoped<IMovimientoService, MovimientoService>();
    webappBuilder.Services.AddScoped<IMovimientoRepository, MovimientoRepository>();
    webappBuilder.Services.AddScoped<IReporteService, ReporteService>();
});

DefaultDistribtWebAPI.Run(app);