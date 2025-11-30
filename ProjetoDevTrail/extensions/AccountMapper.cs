using ProjetoDevTrail.Application.dtos.ViewModel;
using ProjetoDevTrail.Domain.dtos.InputModel;
using ProjetoDevTrail.Domain.Enums;
using ProjetoDevTrail.Domain.Model;


namespace ProjetoDevTrail.Api.extensions
{
    public static class AccountMapper
    {
        public static Conta ToEntity(this ContaInputModel input)
        {
            if (input == null) return null;

            if (!Enum.TryParse<Status>(input.Status, true, out var statusEnum))
            {
                throw new ArgumentException($"O status '{input.Status}' não é válido. Valores aceitos: Ativa, Inativa");
            }

            if (!Enum.TryParse<TipoConta>(input.Tipo, true, out var typeEnum))
            {
                throw new ArgumentException($"O tipo de conta '{input.Tipo}' não é válido. Valores aceitos: Corrente, Poupanca, Investimento.");
            }

            return new Conta
            {
                Id = Guid.NewGuid(),
                Numero = input.Numero,
                Saldo = input.Saldo,
                Status = statusEnum,
                Tipo = typeEnum, 

                ClienteId = input.ClienteId,
                Transacoes = new List<Transacao>()
            };
        }
        public static Conta ToUpdateEntity(this AtualizarContaInputModel input)
        {
            if (input == null) return null;

            if (!Enum.TryParse<Status>(input.Status, true, out var statusEnum))
            {
                throw new ArgumentException($"O status '{input.Status}' não é válido.");
            }

            if (!Enum.TryParse<TipoConta>(input.Tipo, true, out var typeEnum))
            {
                throw new ArgumentException($"O tipo de conta '{input.Tipo}' não é válido. Valores aceitos: Corrente, Poupanca, Investimento.");
            }

            return new Conta
            {
                Numero = input.Numero,
                Status = statusEnum,
                Tipo = typeEnum,

            };
        }

        public static AccountViewModel ToViewModel(this Conta account)
        {
            if (account == null) return null;

            return new AccountViewModel
            {
                Id = account.Id,
                Numero = account.Numero,
                Saldo = account.Saldo,
                Status = account.Status.ToString(),
                Tipo = account.Tipo.ToString(), 

                ClienteId = account.ClienteId
            };
        }
    }
}
