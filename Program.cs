using System.Text.Json;
using System.Text.RegularExpressions;
using ConsumerViaCep.Models;
using static System.Console;

var client = new HttpClient();

WriteLine("Digite o seu CEP: ");
var entrada = ReadLine();

// Limpa mascara: 30130-000 / 30.130-000 -> 30130000
var cep = Regex.Replace(entrada ?? string.Empty, @"\D", "");

if (cep.Length != 8)
{
    WriteLine("CEP invalido. Informe 8 digitos.");
    return;
}

var enderecoUrl = $@"https://viacep.com.br/ws/{cep}/json/";

WriteLine($"Realizando requisicao para o endpoint: {enderecoUrl}");

try
{
    HttpResponseMessage response = await client.GetAsync(enderecoUrl);

    // Status Code da requisicao
    WriteLine("API funcionou: " + response.IsSuccessStatusCode);
    WriteLine("Status Code: " + (int)response.StatusCode + " " + response.StatusCode);

    response.EnsureSuccessStatusCode();

    string responseString = await response.Content.ReadAsStringAsync();

    Endereco? endereco = JsonSerializer.Deserialize<Endereco>(responseString);

    if (endereco is null || endereco.Erro is not null || endereco.Cep is null)
    {
        WriteLine("CEP nao encontrado na base da ViaCEP.");
        return;
    }

    WriteLine();
    WriteLine(endereco);
}
catch (HttpRequestException e)
{
    WriteLine("Falha de comunicacao com a API: " + e.Message);
}
catch (JsonException e)
{
    WriteLine("A resposta nao pode ser convertida em objeto: " + e.Message);
}
catch (Exception e)
{
    WriteLine("Aconteceu um erro ao consultar a api: " + e.Message);
    WriteLine("Erro interno: " + e.InnerException);
}
