using ProjetoDevTrail.Domain.Model;

namespace ProjetoDevTrail.Domain.interfaces.service;

public interface IContaService
{
    Task<Conta> CriarContaAsync(Conta account);
    Task<Conta> UpdateAccountAsync(Guid id,Conta account);

    Task<Conta?> BuscarPorIdAsync(Guid id);
    Task<Conta?> BuscarPorNumeroContaAsync(int numero);
    Task<List<Conta>> ObterContasPorClienteAsync(Guid clienteId);
}
