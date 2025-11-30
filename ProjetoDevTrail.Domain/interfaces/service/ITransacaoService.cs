using ProjetoDevTrail.Domain.Model;

namespace ProjetoDevTrail.Domain.interfaces.service;

public interface ITransacaoService
{
    Task RealizarDepositoAsync(int numeroConta, decimal valor);
    Task RealizarSaqueAsync(int numeroConta, decimal valor);
    Task RealizarTransferenciaAsync(int contaOrigem, int contaDestino, decimal valor);

    Task<List<Transacao>> ObterExtratoAsync(int numeroConta);
}
