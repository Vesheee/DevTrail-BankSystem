using ProjetoDevTrail.Domain.interfaces.repository;
using ProjetoDevTrail.Domain.Model;
using ProjetoDevTrail.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ProjetoDevTrail.Infra.Repository;

public class ClienteRepository(BankContext context) : IClienteRepository
{
    public async Task CriarAsync(Cliente cliente)
    {
        await context.Clientes.AddAsync(cliente);
        await context.SaveChangesAsync();
    }

    public async Task<Cliente?> ObterPorCpfAsync(string cpf)
    {
        var cliente = await context.Clientes
                                   .Where(c => c.Cpf == cpf)
                                   .FirstOrDefaultAsync();
        return cliente;
    }

    public async Task<Cliente?> ObterPorIdAsync(Guid id)
    {
        var cliente = await context.Clientes
                                    .Where(c => c.Id == id)
                                    .FirstOrDefaultAsync();
        return cliente;
    }
}
