using ProjetoDevTrail.Domain.Model;

namespace ProjetoDevTrail.Domain.interfaces.service;

public interface IClienteService
{
    Task<Cliente?> BuscarClientePorIdAsync(Guid id);
    Task<Cliente?> BuscarClientePorCpfAsync(string cpf);
    Task<Cliente> CriarClienteAsync(Cliente cliente);
}
