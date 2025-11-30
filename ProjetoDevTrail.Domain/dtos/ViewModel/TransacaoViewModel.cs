

namespace ProjetoDevTrail.Domain.dtos.ViewModel;

public class TransacaoViewModel
{
    public Guid Id { get; set; }
    public string Tipo { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataHora { get; set; }
    public Guid? ContaOrigemId { get; set; }
    public Guid? ContaDestinoId { get; set; }
}
