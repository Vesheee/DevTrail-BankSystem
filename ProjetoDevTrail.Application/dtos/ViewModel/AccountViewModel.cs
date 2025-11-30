
namespace ProjetoDevTrail.Application.dtos.ViewModel;

public class AccountViewModel
{
    public Guid Id { get; set; }
    public int Numero { get; set; }
    public decimal Saldo { get; set; }
    public string Status { get; set; } = string.Empty;
}
