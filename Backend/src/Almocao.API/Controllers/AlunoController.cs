using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almocao.BLL.Infra;
using Almocao.Entities;
using Almocao.Entities.DTO;
using Almocao.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almocao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private IAlunoBLL _alunoBLL;

        public AlunoController(IAlunoBLL alunoBLL)
        {
            _alunoBLL = alunoBLL;
        }

        [Route("autenticar"), HttpPut]
        public async Task<IActionResult> Autenticar([FromBody] LoginDTO login)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object = await _alunoBLL.AutenticarAsync(login.Usuario, login.Senha);

                if (responseContent.Object == null)
                {
                    responseContent.Message = "Usuário ou Senha Inválidos.";
                    return NotFound(responseContent);
                }

                responseContent.Message = "Operação realizada com sucesso";
                return Ok(responseContent);

            }
            catch (BusinessException bex)
            {
                responseContent.Message = bex.Message;
                return BadRequest(responseContent);
            }
            catch (Exception ex)
            {
                responseContent.Message = ex.Message;
                return BadRequest(responseContent);
            }
        }
    }
}