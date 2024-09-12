using EvoSystems.Controllers.Funcionario.Dto;

namespace EvoSystems.Services.Funcionario;

public class FuncionarioService : IFuncionarioInterface
{
    public Task<List<FuncionarioResonseDto>> GetAllFuncionarios()
    {
        throw new NotImplementedException();
    }

    public Task<FuncionarioResonseDto> CreateFuncionario(FuncionarioRequestDto funcionarioRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<FuncionarioResonseDto> UpdateFuncionario(int funcionarioId, FuncionarioRequestDto funcionarioRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task<FuncionarioResonseDto> DeleteFuncionario(int funcionarioId)
    {
        throw new NotImplementedException();
    }
}