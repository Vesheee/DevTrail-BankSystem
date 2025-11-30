using ProjetoDevTrail.Domain.Model;

namespace ProjetoDevTrail.Domain.interfaces.repository;

public interface IClienteRepository
{
    Task<Cliente?> ObterPorIdAsync(Guid id);
    Task<Cliente?> ObterPorCpfAsync(string cpf);
    Task CriarAsync(Cliente cliente);
}
