using System.ComponentModel.DataAnnotations.Schema;

namespace EvoSystems.Models;

public class Funcionario
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Foto { get; set; }
    public string RG { get; set; }

    // One (departamento) To Many (funcionario)
    public int DepartamentoId { get; set; }
    public Departamento Departamento { get; set; }
}