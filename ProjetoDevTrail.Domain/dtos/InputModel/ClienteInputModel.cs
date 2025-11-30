using System.ComponentModel.DataAnnotations;

namespace ProjetoDevTrail.Application.dtos.InputModel
{
    public class ClienteInputModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public DateOnly DataNascimento { get; set; }
    }
}
