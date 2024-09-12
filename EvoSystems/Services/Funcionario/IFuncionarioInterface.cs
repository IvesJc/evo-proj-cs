using EvoSystems.Controllers.Funcionario.Dto;

namespace EvoSystems.Services.Funcionario;

public interface IFuncionarioInterface
{
    Task<List<FuncionarioResonseDto>> GetAllFuncionarios();
    Task<FuncionarioResonseDto> CreateFuncionario(FuncionarioRequestDto funcionarioRequestDto);
    Task<FuncionarioResonseDto> UpdateFuncionario(int funcionarioId, FuncionarioRequestDto funcionarioRequestDto);
    Task<FuncionarioResonseDto> DeleteFuncionario(int funcionarioId);
}