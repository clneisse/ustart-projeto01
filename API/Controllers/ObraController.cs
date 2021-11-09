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
    [Route("api/v{version:apiVersion}/produto")]
    [Authorize]
    public class ObraController : ControllerBase
    {
        private readonly IObraRepository obraRepository;
        private readonly ObraWorkflow obraWorkflow;

        public ObraController(IObraRepository obraRepository, ObraWorkflow obraWorkflow)
        {
            this.obraRepository = obraRepository;
            this.obraWorkflow = obraWorkflow;
        }

        /// <summary>
        /// Consultar todos os grupos
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult Get([FromQuery] string pesquisa)
        {
            return Ok(obraRepository.Pesquisar(pesquisa));
        }

                /// <summary>
        /// Consultar apenas um grupo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]    
        [Route("{id}")]    
        public IActionResult GetPorId([FromRoute] Guid id)
        {
            return Ok(obraRepository.ConsultarPorId(id));
        }


        /// <summary>
        /// Método para inserir no banco um regitro de grupo produto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Adicionar([FromBody] ObraCommand command )
        {
            obraWorkflow.Add(command);
            if (obraWorkflow.IsValid()){
                return Ok();
            }
            return BadRequest(obraWorkflow.GetErrors());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Atualizar([FromRoute] Guid id, [FromBody] ObraCommand command )
        {
            obraWorkflow.Update(id, command);
            if (obraWorkflow.IsValid()){
                return Ok();
            }
            return BadRequest(obraWorkflow.GetErrors());
        }

        [HttpDelete("{id}")]        
        public IActionResult Excluir([FromRoute] Guid id)
        {
            obraWorkflow.Delete(id);
            if (obraWorkflow.IsValid()){
                return Ok();
            }
            return BadRequest(obraWorkflow.GetErrors());
        }
    }
}
