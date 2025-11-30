using ProjetoDevTrail.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoDevTrail.Domain.Model;

public class Conta
{
    public Guid Id { get; set; }
    public int Numero { get; set; }
    public decimal Saldo { get; set; }
    public Status Status { get; set; }
    public TipoConta Tipo { get; set; }

    public Guid ClienteId { get; set; }
    public Cliente? Cliente { get; set; }

    [NotMapped]
    public List<Transacao> Transacoes { get; set; } = new();

}
