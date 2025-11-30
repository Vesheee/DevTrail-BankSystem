using ProjetoDevTrail.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDevTrail.Domain.dtos.InputModel
{
    public class ContaInputModel
    {
        [Required]
        public int Numero { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "O saldo deve ser um valor não negativo.")]
        public decimal Saldo { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;
        [Required]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Conta Deve ter um Cliente")]
        public Guid ClienteId { get; set; }
    }
}
