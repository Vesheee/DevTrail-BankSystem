using ProjetoDevTrail.Domain.Enums;
using ProjetoDevTrail.Domain.interfaces.repository;
using ProjetoDevTrail.Domain.interfaces.service;
using ProjetoDevTrail.Domain.Model;

namespace ProjetoDevTrail.Application.services;

public class TransacaoAppService(IContaRepository contaRepo, ITransacaoRepository transacaoRepo) : ITransacaoService
{
    public async Task<List<Transacao>> ObterExtratoAsync(int numeroConta)
    {
        return await transacaoRepo.ObterExtratoAsync(numeroConta);
    }
    public async Task RealizarDepositoAsync(int numeroConta, decimal valor)
    {
        if (valor <= 0) throw new ArgumentException("Valor deve ser positivo.");

        var conta = await contaRepo.BuscarPorNumeroContaAsync(numeroConta);
        if (conta == null) throw new KeyNotFoundException("Conta não encontrada.");

        conta.Saldo += valor;

        await contaRepo.AtualizarContaAsync(conta);

        var transacao = new Transacao
        {
            Tipo = TipoTransacaon.Deposito,
            Valor = valor,
            ContaOrigemId = conta.Id, //A origem é a própria conta beneficiada
            ContaDestinoId = null,
            DataHora = DateTime.Now
        };

        await transacaoRepo.RegistrarTransacaoAsync(transacao);
    }
    public async Task RealizarSaqueAsync(int numeroConta, decimal valor)
    {
        if (valor <= 0) throw new ArgumentException("Valor deve ser positivo.");

        var conta = await contaRepo.BuscarPorNumeroContaAsync(numeroConta);
        if (conta == null) throw new KeyNotFoundException("Conta não encontrada.");

        if (conta.Saldo < valor)
            throw new InvalidOperationException("Saldo insuficiente.");

        conta.Saldo -= valor;

        await contaRepo.AtualizarContaAsync(conta);

        var transacao = new Transacao
        {
            Tipo = TipoTransacaon.Saque,
            Valor = valor,
            ContaOrigemId = conta.Id,
            ContaDestinoId = null,
            DataHora = DateTime.Now
        };

        await transacaoRepo.RegistrarTransacaoAsync(transacao);
    }


    public async Task RealizarTransferenciaAsync(int contaOrigem, int contaDestino, decimal valor)
    {
        if (valor <= 0) throw new ArgumentException("Valor deve ser positivo.");

        var origem = await contaRepo.BuscarPorNumeroContaAsync(contaOrigem);
        var destino = await contaRepo.BuscarPorNumeroContaAsync(contaDestino);

        if (origem == null) throw new KeyNotFoundException("Conta Origem não foi encontrada.");
        if (destino == null) throw new KeyNotFoundException("Conta Destino não foi encontrada.");
        if (origem.Saldo < valor) throw new InvalidOperationException("Saldo insuficiente na origem.");

        origem.Saldo -= valor;
        destino.Saldo += valor;

        await contaRepo.AtualizarContaAsync(origem);
        await contaRepo.AtualizarContaAsync(destino);

        var transacaoSaida = new Transacao
        {
            Tipo = TipoTransacaon.TransferenciaSaida, 
            Valor = valor,
            ContaOrigemId = origem.Id,   // Quem pagou (Dono desse registro)
            ContaDestinoId = destino.Id, // Informação extra: para quem foi
            DataHora = DateTime.Now
        };

        var transacaoEntrada = new Transacao
        {
            Tipo = TipoTransacaon.TransferenciaEntrada,
            Valor = valor,
            ContaOrigemId = origem.Id,   
            ContaDestinoId = destino.Id, 
            DataHora = DateTime.Now
        };

        await transacaoRepo.RegistrarTransacaoAsync(transacaoSaida);
        await transacaoRepo.RegistrarTransacaoAsync(transacaoEntrada);
    }



}
