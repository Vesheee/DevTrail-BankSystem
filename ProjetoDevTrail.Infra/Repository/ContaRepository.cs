using ProjetoDevTrail.Domain.interfaces.repository;
using ProjetoDevTrail.Domain.Model;
using ProjetoDevTrail.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ProjetoDevTrail.Infra.Repositories;

public class ContaRepository(BankContext context) : IContaRepository
{
    public async Task<Conta?> BuscarPorIdAsync(Guid id)
    {
        var account = await context.Contas
                            .Include(c => c.Cliente)
                            .AsNoTracking()
                            .Where(c => c.Id == id)
                            .FirstOrDefaultAsync();
        return account;
    }

    public async Task<Conta?> BuscarPorNumeroContaAsync(int numero)
    {
        var account = await context.Contas
                            .Include(c => c.Cliente)
                            .AsNoTracking()
                            .Where(c => c.Numero == numero)
                            .FirstOrDefaultAsync();
        return account;
    }
    public async Task CriarContaAsync(Conta conta)
    {
        await context.AddAsync(conta);
        await context.SaveChangesAsync();
        var contaComCliente = await context.Contas.Include(c => c.Cliente).FirstOrDefaultAsync(c => c.Id == conta.Id);
    }

    public async Task AtualizarContaAsync(Conta conta)
    {
        context.Contas.Update(conta);
        await context.SaveChangesAsync();
    }
    public async Task<List<Conta>> BuscarContasPorClienteIdAsync(Guid clienteId)
    {
        return await context.Contas
            .AsNoTracking()
            .Where(c => c.ClienteId == clienteId)
            .ToListAsync();
    }

}
