namespace ProjetoDevTrail.Application.dtos.InputModel
{
    public class TransactionInputModel
    {
        public Guid ContaOrigemId { get; set; }
        public Guid ContaDestinoId { get; set; }
        public decimal Valor { get; set; }
    }
}
