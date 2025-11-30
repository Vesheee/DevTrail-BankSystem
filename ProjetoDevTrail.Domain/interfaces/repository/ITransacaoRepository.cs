using ProjetoDevTrail.Domain.Model;
using System.Transactions;

namespace ProjetoDevTrail.Domain.interfaces.repository;

public interface ITransacaoRepository
{
    Task RegistrarTransacaoAsync(Transacao transacao);

    Task<List<Transacao>> ObterExtratoAsync(int numeroConta);
}
