using ProjetoPersistenciaSimples.Models.Clientes;
using System.Text.Json;

// Repositories/ClienteRepository.cs
public class ClienteRepository
{
    private readonly string _filePath;

    public ClienteRepository()
    {
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cliente.json");
    }


    public List<Cliente> GetAllClientes()
    {
        if (!File.Exists(_filePath)) return new List<Cliente>();

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Cliente>>(json, new JsonSerializerOptions
        {
            Converters = { new ClienteJsonConverter() },
            PropertyNameCaseInsensitive = true
        }) ?? new List<Cliente>();
    }

    public void SaveCliente(Cliente cliente)
    {
        var clientes = GetAllClientes();
        clientes.Add(cliente);

        var json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions
        {
            Converters = { new ClienteJsonConverter() },
            WriteIndented = true
        });

        File.WriteAllText(_filePath, json);
    }
}


// Repositories/ClienteJsonConverter.cs
public class ClienteJsonConverter : System.Text.Json.Serialization.JsonConverter<Cliente>
{
    public override Cliente Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            if (root.TryGetProperty("CPF", out _))
            {
                return JsonSerializer.Deserialize<PessoaFisica>(root.GetRawText(), options);
            }
            else if (root.TryGetProperty("CNPJ", out _))
            {
                return JsonSerializer.Deserialize<PessoaJuridica>(root.GetRawText(), options);
            }
        }
        throw new JsonException("Tipo de cliente desconhecido.");
    }

    public override void Write(Utf8JsonWriter writer, Cliente value, JsonSerializerOptions options)
    {
        if (value is PessoaFisica pf)
        {
            JsonSerializer.Serialize(writer, pf, options);
        }
        else if (value is PessoaJuridica pj)
        {
            JsonSerializer.Serialize(writer, pj, options);
        }
        else
        {
            throw new JsonException("Tipo de cliente desconhecido.");
        }
    }
}
