using ProjetoDevTrail.Domain.Enums;

namespace ProjetoDevTrail.Domain.Model;

public class Transacao
{
    public Guid Id { get; set; }
    public TipoTransacaon Tipo { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataHora { get; set; }

    //Chaves Estrangeiras
    public Guid? ContaOrigemId { get; set; }
    public Conta? ContaOrigem { get; set; }
    public Guid? ContaDestinoId { get; set; }
    public Conta? ContaDestino { get; set; }
}
