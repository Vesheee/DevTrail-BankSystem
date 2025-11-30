namespace ProjetoDevTrail.Domain.Model;

public class Cliente
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateOnly DataNascimento { get; set; }

    public List<Conta> Contas { get; set; } = new();
}
