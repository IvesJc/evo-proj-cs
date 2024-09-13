using EvoSystems.Controllers.Departamento.Dto;
using EvoSystems.Controllers.Exceptions;
using EvoSystems.Data;
using Microsoft.EntityFrameworkCore;
using InvalidDataException = EvoSystems.Controllers.Exceptions.InvalidDataException;

namespace EvoSystems.Services.Departamento;

public class DepartamentoService : IDepartamentoInterface
{
    private readonly EvoSysContext _context;

    public DepartamentoService(EvoSysContext context)
    {
        _context = context;
    }

    public async Task<List<DepartamentoResponseDto>> GetAllDepartamentos()
    {
        try
        {
            var departamentos = await _context.Departamentos.Include(dep => dep.Funcionarios).ToListAsync();
            if (departamentos == null || !departamentos.Any())
            {
                throw new NotFoundException("No Departamentos were found!");
            }

            var depatamentosDto = departamentos.Select(departamento => new DepartamentoResponseDto()
            {
                Id = departamento.Id,
                Nome = departamento.Nome,
                Sigla = departamento.Sigla,
            }).ToList();
            return depatamentosDto;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            throw;
        }
    }

    public async Task<DepartamentoResponseDto> CreateDepartamento(DepartamentoRequestDto departamentoRequestDto)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(departamentoRequestDto.Nome) ||
                string.IsNullOrWhiteSpace(departamentoRequestDto.Sigla))
            {
                throw new InvalidDataException("Nome or Sigla are invalid!");
            }

            var departamento = new Models.Departamento
            {
                Nome = departamentoRequestDto.Nome,
                Sigla = departamentoRequestDto.Sigla,
            };
            if (string.IsNullOrWhiteSpace(departamentoRequestDto.Nome) ||
                string.IsNullOrWhiteSpace(departamentoRequestDto.Sigla))
            {
                throw new InvalidDataException("Nome or Sigla are invalid!");
            }

            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            DepartamentoResponseDto departamentoResponseDto = new DepartamentoResponseDto
            {
                Id = departamento.Id,
                Nome = departamento.Nome,
                Sigla = departamento.Sigla,
            };
            return departamentoResponseDto;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            throw;
        }
    }

    public async Task<DepartamentoResponseDto> UpdateDepartamento(int idDep,
        DepartamentoRequestDto departamentoRequestDto)
    {
        if (string.IsNullOrWhiteSpace(departamentoRequestDto.Nome) ||
            string.IsNullOrWhiteSpace(departamentoRequestDto.Sigla))
        {
            throw new InvalidDataException("Nome or Sigla are invalid!");
        }

        var depExiste = _context.Departamentos.FirstOrDefault(dep => dep.Id == idDep);
        if (depExiste == null)
        {
            throw new NotFoundException("Departamento not found with ID!");
        }

        depExiste.Nome = departamentoRequestDto.Nome;
        depExiste.Sigla = departamentoRequestDto.Sigla;

        _context.Update(depExiste);
        await _context.SaveChangesAsync();
        DepartamentoResponseDto departamentoResponseDto = new DepartamentoResponseDto
        {
            Id = depExiste.Id,
            Nome = depExiste.Nome,
            Sigla = depExiste.Sigla,
        };
        return departamentoResponseDto;
    }

    public async Task<DepartamentoResponseDto> DeleteDepartamento(int idDep)
    {
        try
        {
            var depExiste = _context.Departamentos.FirstOrDefault(dep => dep.Id == idDep);
            if (depExiste == null)
            {
                throw new NotFoundException("Departamento not found with ID!");
            }

            _context.Departamentos.Remove(depExiste);
            await _context.SaveChangesAsync();
            var departamentoResponseDto = new DepartamentoResponseDto
            {
                Id = depExiste.Id,
                Nome = depExiste.Nome,
                Sigla = depExiste.Sigla,
            };
            return departamentoResponseDto;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            throw;
        }
    }
}