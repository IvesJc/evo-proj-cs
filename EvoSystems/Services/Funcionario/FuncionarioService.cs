using EvoSystems.Controllers.Funcionario.Dto;
using EvoSystems.Data;
using Microsoft.EntityFrameworkCore;

namespace EvoSystems.Services.Funcionario;

public class FuncionarioService : IFuncionarioInterface
{
    private readonly EvoSysContext _context;

    public FuncionarioService(EvoSysContext context)
    {
        _context = context;
    }

    public async Task<List<FuncionarioResonseDto>> GetAllFuncionarios()
    {
        try
        {
            var funcionarios = await _context.Funcionarios.ToListAsync();
            var funcionariosDto = funcionarios.Select(funcionario => new FuncionarioResonseDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Foto = funcionario.Foto,
                Rg = funcionario.RG,
                DepartamentoId = funcionario.DepartamentoId

            }).ToList();
            return funcionariosDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<FuncionarioResonseDto> CreateFuncionario(FuncionarioRequestDto funcionarioRequestDto)
    {
        try
        {
            var funcionario = new Models.Funcionario
            {
                Nome = funcionarioRequestDto.Nome,
                Foto = funcionarioRequestDto.Foto,
                RG = funcionarioRequestDto.Rg,
                DepartamentoId = funcionarioRequestDto.DepartamentoId
            };
            _context.Add(funcionario);
            await _context.SaveChangesAsync();
            var funcionarioResponseDto = new FuncionarioResonseDto
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Foto = funcionario.Foto,
                Rg = funcionario.RG,
                DepartamentoId = funcionario.DepartamentoId
            };
            return funcionarioResponseDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<FuncionarioResonseDto> UpdateFuncionario(int funcionarioId, FuncionarioRequestDto funcionarioRequestDto)
    {
        try
        {
            var funcExiste = _context.Funcionarios.FirstOrDefault(func => func.Id == funcionarioId);
            if (funcExiste != null)
            {
                funcExiste.Nome = funcionarioRequestDto.Nome;
                funcExiste.Foto = funcionarioRequestDto.Foto;
                funcExiste.RG = funcionarioRequestDto.Rg;
                funcExiste.DepartamentoId = funcionarioRequestDto.DepartamentoId;

                _context.Update(funcExiste);
                await _context.SaveChangesAsync();

                var funcionarioResponseDto = new FuncionarioResonseDto
                {
                    Id = funcExiste.Id,
                    Nome = funcExiste.Nome,
                    Foto = funcExiste.Foto,
                    Rg = funcExiste.RG,
                    DepartamentoId = funcExiste.DepartamentoId
                };
                return funcionarioResponseDto;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();

    }

    public async Task<FuncionarioResonseDto> DeleteFuncionario(int funcionarioId)
    {
        var funcExiste = _context.Funcionarios.FirstOrDefault(func => func.Id == funcionarioId);
        if (funcExiste != null)
        {
            _context.Remove(funcExiste);
            await _context.SaveChangesAsync();
            var funcionarioResponseDto = new FuncionarioResonseDto
            {
                Id = funcExiste.Id,
                Nome = funcExiste.Nome,
                Foto = funcExiste.Foto,
                Rg = funcExiste.RG,
                DepartamentoId = funcExiste.DepartamentoId
            };
            return funcionarioResponseDto;
        }
        throw new NotImplementedException();

    }
}