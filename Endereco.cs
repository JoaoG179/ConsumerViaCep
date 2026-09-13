using System.Text.Json.Serialization;

namespace ConsumerViaCep.Models;

public class Endereco
{
    [JsonPropertyName("cep")]
    public string? Cep { get; set; }

    [JsonPropertyName("logradouro")]
    public string? Logradouro { get; set; }

    [JsonPropertyName("complemento")]
    public string? Complemento { get; set; }

    [JsonPropertyName("unidade")]
    public string? Unidade { get; set; }

    [JsonPropertyName("bairro")]
    public string? Bairro { get; set; }

    [JsonPropertyName("localidade")]
    public string? Localidade { get; set; }

    [JsonPropertyName("uf")]
    public string? Uf { get; set; }

    [JsonPropertyName("estado")]
    public string? Estado { get; set; }

    [JsonPropertyName("regiao")]
    public string? Regiao { get; set; }

    [JsonPropertyName("ibge")]
    public string? Ibge { get; set; }

    [JsonPropertyName("gia")]
    public string? Gia { get; set; }

    [JsonPropertyName("ddd")]
    public string? Ddd { get; set; }

    [JsonPropertyName("siafi")]
    public string? Siafi { get; set; }

    // A ViaCEP devolve {"erro": "true"} quando o CEP nao existe
    [JsonPropertyName("erro")]
    public string? Erro { get; set; }

    public override string ToString() =>
        $"""
        CEP........: {Cep}
        Rua........: {Logradouro}
        Complemento: {Complemento}
        Bairro.....: {Bairro}
        Cidade.....: {Localidade}
        UF.........: {Uf} ({Estado})
        Regiao.....: {Regiao}
        DDD........: {Ddd}
        IBGE.......: {Ibge}
        """;
}
