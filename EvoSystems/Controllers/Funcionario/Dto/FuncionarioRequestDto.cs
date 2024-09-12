namespace EvoSystems.Controllers.Funcionario.Dto;

public record FuncionarioRequestDto(
    string Nome,
    string Foto,
    string Rg,
    int DepartamentoId);