using System.ComponentModel.DataAnnotations;

namespace ProjetoDevTrail.Application.dtos.InputModel
{
    public class AccountInputModel
    {
        [Required]
        public int Numero { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "O saldo deve ser um valor não negativo.")]
        public decimal Saldo { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "Conta Deve ter um Cliente")]
        public Guid ClienteId { get; set; }

    }
}
