namespace EvoSystems.Controllers.Funcionario.Dto;

public class FuncionarioRequestDto
{
    public string Nome { get; set; }
    public string Foto { get; set; }
    public string Rg { get; set; }
    public int DepartamentoId { get; set; }
}