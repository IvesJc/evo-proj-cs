using EvoSystems.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoSystems.Data;

public class EvoSysContext : DbContext
{
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    
    public EvoSysContext(DbContextOptions options) : base(options)
    {
    }
}