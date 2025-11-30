using System.ComponentModel.DataAnnotations;

namespace ProjetoDevTrail.Application.dtos.InputModel
{
    public class TransacaoAtomicaInputModel
    {
        [Required]
        public int ContaOrigem { get; set; }
        [Required]
        public int ContaDestino { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}
