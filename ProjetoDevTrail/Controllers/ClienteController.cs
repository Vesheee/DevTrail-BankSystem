
using Microsoft.AspNetCore.Mvc;
using ProjetoDevTrail.Application.dtos.InputModel;
using ProjetoDevTrail.Application.dtos.ViewModel;
using ProjetoDevTrail.Domain.interfaces.service;
using ProjetoDevTrail.Api.extensions;

namespace ProjetoDevTrail.Infra.Configurations;

[ApiController]
[Route("[controller]")]
public class ClienteController(IClienteService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CriarClienteAsync([FromBody] ClienteInputModel input)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var novoCliente = input.ToEntity();
            var clienteCriado = await service.CriarClienteAsync(novoCliente);
            var viewModel = clienteCriado.ToViewModel();

            return CreatedAtRoute("ObterClientePorId", new { id = viewModel.Id }, viewModel);
        }
        catch (InvalidOperationException ex) 
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpGet("{id}", Name = "ObterClientePorId")]
    public async Task<ActionResult<ClientViewModel>> ObterPorIdAsync(Guid id)
    {
        var cliente = await service.BuscarClientePorIdAsync(id);

        if (cliente == null) return NotFound("Cliente não encontrado.");

        return Ok(cliente.ToViewModel());
    }

    [HttpGet("cpf/{cpf}")]
    public async Task<ActionResult<ClientViewModel>> ObterPorCpfAsync(string cpf)
    {
        var cliente = await service.BuscarClientePorCpfAsync(cpf);

        if (cliente == null) return NotFound("Cliente não encontrado com este CPF.");

        return Ok(cliente.ToViewModel());
    }
}
