
using Microsoft.EntityFrameworkCore;
using ProjetoDevTrail.Domain.Model;
namespace ProjetoDevTrail.Infra.Context;

public class BankContext(DbContextOptions<BankContext> options) : DbContext(options)
{
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Transacao> Transacoes  { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Conta>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Numero).IsRequired();
            entity.Property(e => e.Saldo).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.Tipo).IsRequired();

            entity.HasOne(e => e.Cliente)
                  .WithMany(c => c.Contas)
                  .HasForeignKey(e => e.ClienteId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Cpf).IsRequired().HasMaxLength(14);
        });

        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Valor).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(e => e.Tipo).IsRequired().HasConversion<int>();

            entity.HasOne(t => t.ContaOrigem)
                  .WithMany()
                  .HasForeignKey(t => t.ContaOrigemId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.ContaDestino)
                  .WithMany()
                  .HasForeignKey(t => t.ContaDestinoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
