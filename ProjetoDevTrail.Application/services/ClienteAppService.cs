using ProjetoDevTrail.Domain.interfaces.repository;
using ProjetoDevTrail.Domain.interfaces.service;
using ProjetoDevTrail.Domain.Model;

namespace ProjetoDevTrail.Application.services;

public class ClienteAppService(IClienteRepository clienteRepo) : IClienteService
{

    public async Task<Cliente> CriarClienteAsync(Cliente cliente)
    {
        var clienteExistente = await clienteRepo.ObterPorCpfAsync(cliente.Cpf);
        if (clienteExistente != null)
        {
            throw new InvalidOperationException("Já existe um cliente cadastrado com este CPF.");
        }

        await clienteRepo.CriarAsync(cliente);
        return cliente;
    }

    public async Task<Cliente?> BuscarClientePorIdAsync(Guid id)
    {
        return await clienteRepo.ObterPorIdAsync(id);
    }

    public async Task<Cliente?> BuscarClientePorCpfAsync(string cpf)
    {
        return await clienteRepo.ObterPorCpfAsync(cpf);
    }
}
