
using Microsoft.AspNetCore.Mvc;
using ProjetoDevTrail.Api.extensions;
using ProjetoDevTrail.Application.dtos.InputModel;
using ProjetoDevTrail.Domain.interfaces.repository;
using ProjetoDevTrail.Domain.interfaces.service;

namespace ProjetoDevTrail.Infra.Configurations;
[ApiController]
[Route("[controller]")]
public class TransacaoController(ITransacaoService service) : ControllerBase
{
    [HttpPost("deposito")]
    public async Task<IActionResult> Depositar([FromBody] TransacaoInputModel input)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            await service.RealizarDepositoAsync(input.NumeroConta, input.Valor);
            return Ok("Depósito realizado com sucesso.");
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpPost("saque")]
    public async Task<IActionResult> Sacar([FromBody] TransacaoInputModel input)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            await service.RealizarSaqueAsync(input.NumeroConta, input.Valor);
            return Ok("Saque realizado com sucesso.");
        }
        catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpPost("transferencia")]
    public async Task<IActionResult> Transferir([FromBody] TransacaoAtomicaInputModel input)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            await service.RealizarTransferenciaAsync(input.ContaOrigem, input.ContaDestino, input.Valor);
            return Ok("Transferência realizada com sucesso.");
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    [HttpGet("{numeroConta}/extrato")]
    public async Task<IActionResult> Extrato(int numeroConta)
    {
        var transacoesEntities = await service.ObterExtratoAsync(numeroConta);

        var viewModel = transacoesEntities.Select(t => t.ToViewModel());

        return Ok(viewModel);
    }
}
