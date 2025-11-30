using ProjetoDevTrail.Application.dtos.InputModel;
using ProjetoDevTrail.Application.dtos.ViewModel;
using ProjetoDevTrail.Domain.Model;
namespace ProjetoDevTrail.Domain.interfaces.repository;

public interface IContaRepository
{
    Task<Conta?> BuscarPorIdAsync(Guid id);
    Task<Conta?> BuscarPorNumeroContaAsync(int numero);
    Task CriarContaAsync(Conta conta);
    Task AtualizarContaAsync(Conta conta);
    Task<List<Conta>> BuscarContasPorClienteIdAsync(Guid clienteId);
}
