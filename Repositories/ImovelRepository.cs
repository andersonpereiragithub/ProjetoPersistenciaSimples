using System.Text.Json;

public class ImovelRepository
{
    private readonly string _filePath;

    public ImovelRepository()
    {
        // Define o caminho do arquivo dentro da pasta Data
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "imoveis.json");

        // Cria a pasta Data se não existir
        Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
    }

    public List<Imovel> GetAllImoveis()
    {
        if (!File.Exists(_filePath)) return new List<Imovel>();

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Imovel>>(json, new JsonSerializerOptions
        {
            Converters = { new ClienteJsonConverter() },
            PropertyNameCaseInsensitive = true
        }) ?? new List<Imovel>();
    }

    public void SaveImovel(Imovel imovel)
    {
        var imoveis = GetAllImoveis();
        imoveis.Add(imovel);

        var json = JsonSerializer.Serialize(imoveis, new JsonSerializerOptions
        {
            Converters = { new ClienteJsonConverter() },
            WriteIndented = true
        });

        File.WriteAllText(_filePath, json);
    }
}
