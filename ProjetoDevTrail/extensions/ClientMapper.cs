using ProjetoDevTrail.Application.dtos.InputModel;
using ProjetoDevTrail.Application.dtos.ViewModel;
using ProjetoDevTrail.Domain.Model;

namespace ProjetoDevTrail.Api.extensions
{
    public static class ClientMapper
    {
        // Converte Input -> Entidade
        public static Cliente ToEntity(this ClienteInputModel input)
        {
            if (input == null) return null;

            return new Cliente
            {
                // Id é gerado automaticamente na classe Client, não precisamos setar aqui
                Nome = input.Nome,
                Cpf = input.Cpf, // Lembre-se de remover formatação (pontos e traços) se necessário
                DataNascimento = input.DataNascimento
            };
        }

        // Converte Entidade -> ViewModel
        public static ClientViewModel ToViewModel(this Cliente client)
        {
            if (client == null) return null;

            return new ClientViewModel
            {
                Id = client.Id,
                Nome = client.Nome,
                Cpf = client.Cpf,
                // Formata a data para padrão brasileiro dd/MM/yyyy
                DataNascimentoFormatada = client.DataNascimento.ToString("dd/MM/yyyy")
            };
        }

    }
}
