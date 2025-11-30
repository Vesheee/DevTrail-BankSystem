using System.ComponentModel.DataAnnotations;

namespace ProjetoDevTrail.Application.dtos.InputModel
{
    public class TransacaoInputModel
    {
        [Required]
        public int NumeroConta { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}
