
using Microsoft.EntityFrameworkCore;
using ProjetoDevTrail.Domain.Enums;
using ProjetoDevTrail.Domain.interfaces.repository;
using ProjetoDevTrail.Domain.Model;
using ProjetoDevTrail.Infra.Context;

namespace ProjetoDevTrail.Infra.Repository;

public class TransacaoRepository(BankContext context) : ITransacaoRepository
{
    public async Task RegistrarTransacaoAsync(Transacao transacao)
    {
        await context.Transacoes.AddAsync(transacao);
        await context.SaveChangesAsync();
    }

    public async Task<List<Transacao>> ObterExtratoAsync(int numeroConta)
    {
        return await context.Transacoes
        .Include(t => t.ContaOrigem)
        .Include(t => t.ContaDestino)
        .Where(t =>
            (t.ContaOrigem != null && t.ContaOrigem.Numero == numeroConta &&
             (t.Tipo == TipoTransacaon.TransferenciaSaida ||
              t.Tipo == TipoTransacaon.Saque ||
              t.Tipo == TipoTransacaon.Deposito))

            ||
            (t.ContaDestino != null && t.ContaDestino.Numero == numeroConta &&
             (t.Tipo == TipoTransacaon.TransferenciaEntrada))
        )
        .OrderByDescending(t => t.DataHora)
        .ToListAsync();
    }
}
