using System.ComponentModel.DataAnnotations;

namespace ProjetoDevTrail.Domain.dtos.InputModel;

public class AtualizarContaInputModel
{
    [Required]
    public int Numero { get; set; }
    [Required]
    public string Status { get; set; } = string.Empty;
    [Required]
    public string Tipo { get; set; }

}
