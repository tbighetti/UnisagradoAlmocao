using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almocao.BLL;
using Almocao.BLL.Infra;
using Almocao.Entities.DTO;
using Almocao.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almocao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private IVotoBLL _votoBLL;

        public VotoController(IVotoBLL votoBLL)
        {
            _votoBLL = votoBLL;
        }

        [Route("status"), HttpGet]
        public IActionResult Status(string usuario, string senha)
        {
            var responseContent = new ResponseContent();

            try
            {
                responseContent.Object =  _votoBLL.Status(usuario, senha);

                if (responseContent.Object == null)
                {
                    responseContent.Message = "A pesquisa não retornou dados.";
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

        [Route("confirmar"), HttpPost]
        public async Task<IActionResult> Confirmar([FromBody] VotoConfirmadoDTO votoConfirmadoDTO)
        {
            var responseContent = new ResponseContent();

            try
            {
                await _votoBLL.ConfirmarAsync(votoConfirmadoDTO.Usuario, votoConfirmadoDTO.Senha, votoConfirmadoDTO.RestauranteId);
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