using EvoSystems.Models;

namespace EvoSystems.Controllers.Departamento.Dto;

public record DepartamentoResponseDto(
    int Id,
    string Nome,
    string Sigla,
    List<Funcionario> Funcionarios
    );