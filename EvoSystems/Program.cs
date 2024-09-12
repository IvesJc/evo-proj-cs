using EvoSystems.Data;
using EvoSystems.Services.Departamento;
using EvoSystems.Services.Funcionario;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Config
builder.Services.AddDbContext<EvoSysContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"));
});

builder.Services.AddScoped<IDepartamentoInterface, DepartamentoService>();
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();