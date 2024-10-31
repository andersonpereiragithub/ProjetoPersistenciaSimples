using ProjetoPersistenciaSimples.Models.Clientes;

public class Imovel
{
    public int Id { get; set; }
    public Cliente Proprietario { get; set; }
    public string Endereco { get; set; }
    public string InscricaoIPTU { get; set; }
}