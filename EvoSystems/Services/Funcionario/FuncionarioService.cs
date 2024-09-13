using EvoSystems.Controllers.Exceptions;
using EvoSystems.Controllers.Funcionario.Dto;
using EvoSystems.Data;
using Microsoft.EntityFrameworkCore;
using InvalidDataException = EvoSystems.Controllers.Exceptions.InvalidDataException;

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
            List<Models.Funcionario> funcionarios = await _context.Funcionarios.ToListAsync();
            if (funcionarios == null || !funcionarios.Any())
            {
                throw new NotFoundException("No Funcionarios were found");
            }

            var funcionariosDto = funcionarios.Select(funcionario =>
            {
                if (string.IsNullOrWhiteSpace(funcionario.Nome) || funcionario.DepartamentoId <= 0)
                {
                    throw new InvalidDataException("Nome is null or DepartamentoId invalid!");
                }

                return new FuncionarioResonseDto()
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    Foto = funcionario.Foto,
                    Rg = funcionario.RG,
                    DepartamentoId = funcionario.DepartamentoId
                };
            }).ToList();
            return funcionariosDto;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            throw;
        }
    }

    public async Task<FuncionarioResonseDto> CreateFuncionario(FuncionarioRequestDto funcionarioRequestDto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(funcionarioRequestDto.Nome) || funcionarioRequestDto.DepartamentoId <= 0)
            {
                throw new InvalidDataException("Nome is null or DepartamentoId invalid!");
            }

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
            Console.WriteLine("Error: " + e.Message);
            throw;
        }
    }

    public async Task<FuncionarioResonseDto> UpdateFuncionario(int funcionarioId,
        FuncionarioRequestDto funcionarioRequestDto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(funcionarioRequestDto.Nome) ||
                string.IsNullOrWhiteSpace(funcionarioRequestDto.Rg) || funcionarioRequestDto.DepartamentoId <= 0)
            {
                throw new InvalidDataException("Data can not be null!");
            }

            var funcExiste = _context.Funcionarios.FirstOrDefault(func => func.Id == funcionarioId);
            if (funcExiste == null)
            {
                throw new NotFoundException($"Funcionario ID: {funcionarioId} not found!");
            }

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
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            throw;
        }
    }

    public async Task<FuncionarioResonseDto> DeleteFuncionario(int funcionarioId)
    {
        var funcExiste = _context.Funcionarios.FirstOrDefault(func => func.Id == funcionarioId);
        if (funcExiste == null)
        {
            throw new NotFoundException($"Funcionario ID: {funcionarioId} not found!");
        }

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
}