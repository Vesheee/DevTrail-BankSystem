using System.Text.Json.Serialization;

namespace ProjetoDevTrail.Domain.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoTransacaon
{
    Deposito = 1,
    Saque = 2,
    TransferenciaEntrada = 3,
    TransferenciaSaida = 4
}
