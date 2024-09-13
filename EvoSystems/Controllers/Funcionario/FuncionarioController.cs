using EvoSystems.Controllers.Funcionario.Dto;
using EvoSystems.Services.Funcionario;
using Microsoft.AspNetCore.Mvc;

namespace EvoSystems.Controllers.Funcionario
{
    [Route("/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _interface;

        public FuncionarioController(IFuncionarioInterface @interface)
        {
            _interface = @interface;
        }

        [HttpGet]
        public async Task<ActionResult<List<FuncionarioResonseDto>>> GetAllFuncionarios()
        {
            var funcionarios = await _interface.GetAllFuncionarios();
            return Ok(funcionarios);
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioResonseDto>> CreateFuncionario(
            FuncionarioRequestDto funcionarioRequestDto)
        {
            var funcionario = await _interface.CreateFuncionario(funcionarioRequestDto);
            return Created(Uri.UriSchemeHttp, funcionario);
        }

        [HttpPut("/{idFunc}")]
        public async Task<ActionResult<FuncionarioResonseDto>> UpdateFuncionario(int idFunc,
            FuncionarioRequestDto funcionarioRequestDto)
        {
            var funcionario = await _interface.UpdateFuncionario(idFunc, funcionarioRequestDto);
            return Ok(funcionario);
        }

        [HttpDelete("/{idFunc}")]
        public async Task<ActionResult<FuncionarioResonseDto>> DeleteFuncionario(int idFunc)
        {
            var funcionario = await _interface.DeleteFuncionario(idFunc);
            return NoContent();
        }
    }
}
