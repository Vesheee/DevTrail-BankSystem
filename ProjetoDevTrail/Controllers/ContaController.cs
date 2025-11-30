
using Microsoft.AspNetCore.Mvc;
using ProjetoDevTrail.Api.extensions;
using ProjetoDevTrail.Application.dtos.InputModel;
using ProjetoDevTrail.Application.dtos.ViewModel;
using ProjetoDevTrail.Domain.dtos.InputModel;
using ProjetoDevTrail.Domain.interfaces.service;

namespace ProjetoDevTrail.Infra.Configurations;

[ApiController]
[Route("[controller]")]
public class ContaController(IContaService service) : ControllerBase
{
    [HttpGet("{id}", Name = "ObterContaPorId")]
    public async Task<ActionResult<AccountViewModel>> ObterPorIdAsync(Guid id)
    {
        var conta = await service.BuscarPorIdAsync(id);

        if (conta == null) return NotFound("Conta não encontrada.");

        return Ok(conta.ToViewModel());
    }

    [HttpGet("numero/{numeroConta}")]
    public async Task<ActionResult<AccountViewModel>> ObterPorNumeroAsync(int numeroConta)
    {
        var conta = await service.BuscarPorNumeroContaAsync(numeroConta);

        if (conta == null) return NotFound("Conta não encontrada.");

        return Ok(conta.ToViewModel());
    }

    [HttpGet("cliente/{clienteId}")]
    public async Task<IActionResult> ContasPorCliente(Guid clienteId)
    {
        var contasEntities = await service.ObterContasPorClienteAsync(clienteId);

        // Garanta que seu método ToViewModel() existe na classe Account
        var viewModel = contasEntities.Select(c => c.ToViewModel());

        return Ok(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CriarContaAsync([FromBody] ContaInputModel conta)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            var contaEntity = conta.ToEntity();

            var createdAccount = await service.CriarContaAsync(contaEntity);

            var viewModel = createdAccount.ToViewModel();

            return CreatedAtRoute("ObterContaPorId", new { id = viewModel.Id }, viewModel);
        }
        catch (ArgumentException ex) 
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarAsync(Guid id, [FromBody] AtualizarContaInputModel conta)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var account = await service.BuscarPorIdAsync(id);
        if (account == null) return NotFound("Conta não encontrada.");

        var accountToUpdate = conta.ToUpdateEntity();
        accountToUpdate.Id = id; 

        await service.UpdateAccountAsync(id, accountToUpdate);

        return NoContent();

    }
}
