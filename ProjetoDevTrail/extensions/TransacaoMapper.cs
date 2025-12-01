using ProjetoDevTrail.Domain.dtos.ViewModel;
using ProjetoDevTrail.Domain.Model;
namespace ProjetoDevTrail.Api.extensions
{
    public static class TransacaoMapper
    {
        public static TransacaoViewModel ToViewModel(this Transacao t)
        {
            if (t == null) return null;

            return new TransacaoViewModel
            {
                Id = t.Id,
                Valor = t.Valor,
                DataHora = t.DataHora,
                Tipo = t.Tipo.ToString(), 
                ContaOrigemId = t.ContaOrigemId,
                ContaDestinoId = t.ContaDestinoId
            };
        }
    }
}
