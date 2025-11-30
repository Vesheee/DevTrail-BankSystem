using ProjetoDevTrail.Domain.Enums;
using ProjetoDevTrail.Domain.interfaces.repository;
using ProjetoDevTrail.Domain.interfaces.service;
using ProjetoDevTrail.Domain.Model;

namespace ProjetoDevTrail.Application.services;

public class ContaAppService(IContaRepository contaRepo) : IContaService
{
    public async Task<Conta?> BuscarPorIdAsync(Guid id)
    {
        var account = await contaRepo.BuscarPorIdAsync(id);
        if (account == null) return null;

        return account;
    }

    public async Task<Conta?> BuscarPorNumeroContaAsync(int numero)
    {
        var conta = await contaRepo.BuscarPorNumeroContaAsync(numero);
        if (conta == null) return null;

        return conta;
    }
    public async Task<List<Conta>> ObterContasPorClienteAsync(Guid clienteId)
    {
        return await contaRepo.BuscarContasPorClienteIdAsync(clienteId);
    }

    public async Task<Conta> UpdateAccountAsync(Guid id, Conta conta)
    {
        var contaExistente = await contaRepo.BuscarPorIdAsync(id);
        if (contaExistente == null) return null;
        contaExistente.Numero = conta.Numero;
        contaExistente.Status = conta.Status;
        contaExistente.Tipo = conta.Tipo;

        await contaRepo.AtualizarContaAsync(contaExistente);

        return contaExistente;
    }
    public async Task<Conta> CriarContaAsync(Conta conta)
    {
        var existente = await contaRepo.BuscarPorNumeroContaAsync(conta.Numero);
        if (existente != null) throw new InvalidOperationException("Número de conta já existe.");

        var account = new Conta
        {
            Id = Guid.NewGuid(),
            Numero = conta.Numero,
            Saldo = conta.Saldo,
            Status = Status.Ativa,
            ClienteId = conta.ClienteId
        };

        await contaRepo.CriarContaAsync(conta);

        return account;
    }
}