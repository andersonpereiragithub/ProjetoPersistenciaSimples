// Controllers/ImovelController.cs
using ProjetoPersistenciaSimples.Services;
using System;
using System.Collections.Generic;

public class ImovelController
{
    private readonly ImovelService _imovelService;
    private readonly ClienteController _clienteController;

    public ImovelController()
    {
        _imovelService = new ImovelService();
        _clienteController = new ClienteController();
    }

    public void CadastrarImovel(string endereco, string inscricaoIPTU, int proprietarioId)
    {
        var proprietario = _clienteController.ListarClientes().Find(c => c.Id == proprietarioId);
        if (proprietario == null)
        {
            Console.WriteLine("Proprietário não encontrado!");
            return;
        }

        var imovel = new Imovel
        {
            Id = _imovelService.ObterImoveis().Count + 1,
            Proprietario = proprietario,
            Endereco = endereco,
            InscricaoIPTU = inscricaoIPTU
        };

        _imovelService.CadastrarImovel(imovel);
        Console.WriteLine("Imóvel cadastrado com sucesso.");
    }

    public List<Imovel> ListarImoveis()
    {
        return _imovelService.ObterImoveis();
    }
}
