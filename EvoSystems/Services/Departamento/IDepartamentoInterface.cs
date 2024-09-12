using EvoSystems.Controllers.Departamento.Dto;
using EvoSystems.Models;

namespace EvoSystems.Services.Departamento;

public interface IDepartamentoInterface
{
    Task<List<DepartamentoResponseDto>> GetAllDepartamentos();
    Task<DepartamentoResponseDto> CreateDepartamento(DepartamentoRequestDto departamentoRequestDto);
    Task<DepartamentoResponseDto> UpdateDepartamento(int idDep, DepartamentoRequestDto departamentoRequestDto);
    Task<DepartamentoResponseDto> DeleteDepartamento(int idDep);
    

}