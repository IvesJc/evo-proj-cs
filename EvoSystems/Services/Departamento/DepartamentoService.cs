using EvoSystems.Controllers.Departamento.Dto;
using EvoSystems.Data;
using Microsoft.EntityFrameworkCore;

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
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<DepartamentoResponseDto> CreateDepartamento(DepartamentoRequestDto departamentoRequestDto)
    {
        try
        {
            var departamento = new Models.Departamento
            {
                Nome = departamentoRequestDto.Nome,
                Sigla = departamentoRequestDto.Sigla,
            };
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
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<DepartamentoResponseDto> UpdateDepartamento(int idDep, DepartamentoRequestDto departamentoRequestDto)
    {
        var depExiste = _context.Departamentos.FirstOrDefault(dep => dep.Id == idDep);
        if (depExiste != null)
        {
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

        throw new NotImplementedException();
    }

    public async Task<DepartamentoResponseDto> DeleteDepartamento(int idDep)
    {
        try
        {
            var depExiste = _context.Departamentos.FirstOrDefault(dep => dep.Id == idDep);
            if (depExiste != null)
            {
                _context.Departamentos.Remove(depExiste);
                await _context.SaveChangesAsync();
                DepartamentoResponseDto departamentoResponseDto = new DepartamentoResponseDto
                {
                    Id = depExiste.Id,
                    Nome = depExiste.Nome,
                    Sigla = depExiste.Sigla,
                };
                return departamentoResponseDto;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }
}