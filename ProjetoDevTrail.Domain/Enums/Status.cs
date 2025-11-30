using System.Text.Json.Serialization;

namespace ProjetoDevTrail.Domain.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    Ativa,
    Inativa
}
