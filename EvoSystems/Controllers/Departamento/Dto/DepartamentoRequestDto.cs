﻿using EvoSystems.Models;

namespace EvoSystems.Controllers.Departamento.Dto;

public record DepartamentoRequestDto(
    string Nome,
    string Sigla,
    List<Funcionario> Funcionarios
    );