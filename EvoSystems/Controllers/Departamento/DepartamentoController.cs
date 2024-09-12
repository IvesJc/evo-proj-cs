using EvoSystems.Controllers.Departamento.Dto;
using EvoSystems.Services.Departamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoSystems.Controllers.Departamento
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoInterface _interface;

        public DepartamentoController(IDepartamentoInterface @interface)
        {
            _interface = @interface;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartamentoResponseDto>>> GetAllDepartamentos()
        {
            var departamentos = await _interface.GetAllDepartamentos();
            return Ok(departamentos);
        }

        [HttpPost]
        public async Task<ActionResult<List<DepartamentoResponseDto>>> CreateDepartamento(DepartamentoRequestDto departamentoRequestDto)
        {
            var departamento = await _interface.CreateDepartamento(departamentoRequestDto);
            return Created(Uri.UriSchemeHttp, departamento);
        }

        [HttpPut("{idDep}")]
        public async Task<ActionResult<DepartamentoResponseDto>> UpdateDepartamento(int idDep,
            DepartamentoRequestDto departamentoRequestDto)
        {
            var departamento = await _interface.UpdateDepartamento(idDep, departamentoRequestDto);
            return Ok(departamento);
        }

        [HttpDelete("{idDep}")]
        public async Task<ActionResult<DepartamentoResponseDto>> DeleteDepartamento(int idDep)
        {
            var departamento = await _interface.DeleteDepartamento(idDep);
            return Ok(departamento);
        }
        
    }
}
