using System.Text.Json;

namespace ProjetoPersistenciaSimples.Repositories
{// Repositories/ImovelRepository.cs
    public class ImovelRepository
    {
        private const string FilePath = "imoveis.json";

        public List<Imovel> GetAllImoveis()
        {
            if (!File.Exists(FilePath)) return new List<Imovel>();

            var json = File.ReadAllText(FilePath);
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

            File.WriteAllText(FilePath, json);
        }
    }
}
