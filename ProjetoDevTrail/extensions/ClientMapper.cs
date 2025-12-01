using ProjetoDevTrail.Application.dtos.InputModel;
using ProjetoDevTrail.Application.dtos.ViewModel;
using ProjetoDevTrail.Domain.Model;

namespace ProjetoDevTrail.Api.extensions
{
    public static class ClientMapper
    {

        public static Cliente ToEntity(this ClienteInputModel input)
        {
            if (input == null) return null;

            return new Cliente
            {
                Nome = input.Nome,
                Cpf = input.Cpf, 
                DataNascimento = input.DataNascimento
            };
        }

        public static ClientViewModel ToViewModel(this Cliente client)
        {
            if (client == null) return null;

            return new ClientViewModel
            {
                Id = client.Id,
                Nome = client.Nome,
                Cpf = client.Cpf,
                DataNascimentoFormatada = client.DataNascimento.ToString("dd/MM/yyyy")
            };
        }

    }
}
