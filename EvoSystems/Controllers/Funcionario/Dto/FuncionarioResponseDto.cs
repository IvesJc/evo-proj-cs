namespace EvoSystems.Controllers.Funcionario.Dto;

public record FuncionarioResonseDto(    
    int Id,
    string Nome,
    string Foto,
    string Rg,
    int DepartamentoId);