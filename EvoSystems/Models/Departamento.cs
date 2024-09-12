namespace EvoSystems.Models;

public class Departamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }

    // One (dep) To Many (func)
    // public int FuncionarioId { get; set; }
    public List<Funcionario> Funcionarios { get; set; }
}