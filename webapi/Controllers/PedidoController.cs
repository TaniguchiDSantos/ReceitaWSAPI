using FluentAssertions.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReceitaWSAPI.Application.Interfaces;
using ReceitaWSAPI.Application.Models;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoAppService _service;

        public PedidoController(IPedidoAppService PedidoAppService) 
        {
            _service = PedidoAppService ?? throw new ArgumentNullException(nameof(PedidoAppService));
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("")]
        [Authorize]
        public async Task<List<PedidoViewModel>> getAllPedidoAsync()
        {
            return await _service.getAllPedidoAsync();
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("searchCNPJ/{cnpj}")]
        [Authorize]
        public async Task<IActionResult> CNPJSerachAsync(string cnpj)
        {
            await _service.CNPJSerachAsync(cnpj);
            return Ok();
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<IActionResult> AddAsync([FromBody] PedidoViewModel viewModel)

        {
            await _service.AddAsync(viewModel);
            return Ok();
        }
    }
}
