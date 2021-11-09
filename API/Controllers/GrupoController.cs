using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Workflows;

namespace UStart.API.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/grupo")]
    [Authorize]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoRepository grupoRepository;
        private readonly GrupoWorkflow grupoWorkflow;

        public GrupoController(IGrupoRepository grupoRepository, GrupoWorkflow grupoWorkflow)
        {
            this.grupoRepository = grupoRepository;
            this.grupoWorkflow = grupoWorkflow;
        }

        /// <summary>
        /// Consultar todos os grupos
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult GetGrupos([FromQuery] string pesquisa)
        {
            return Ok(grupoRepository.Pesquisar(pesquisa));
        }

                /// <summary>
        /// Consultar apenas um grupo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]    
        [Route("{id}")]    
        public IActionResult GetGrupo([FromRoute] Guid id)
        {
            return Ok(grupoRepository.ConsultarPorId(id));
        }


        /// <summary>
        /// Método para inserir no banco um regitro de grupo produto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AdicionarGrupo([FromBody] GrupoCommand command )
        {
            grupoWorkflow.Add(command);
            if (grupoWorkflow.IsValid()){
                return Ok();
            }
            return BadRequest(grupoWorkflow.GetErrors());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarGrupo([FromRoute] Guid id, [FromBody] GrupoCommand command )
        {
            grupoWorkflow.Update(id, command);
            if (grupoWorkflow.IsValid()){
                return Ok();
            }
            return BadRequest(grupoWorkflow.GetErrors());
        }

        [HttpDelete("{id}")]        
        public IActionResult ExcluirGrupo([FromRoute] Guid id)
        {
            grupoWorkflow.Delete(id);
            if (grupoWorkflow.IsValid()){
                return Ok();
            }
            return BadRequest(grupoWorkflow.GetErrors());
        }
    }
}
