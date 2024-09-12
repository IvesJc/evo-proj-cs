using EvoSystems.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoSystems.Data;

public class AppDbContext : DbContext
{
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}