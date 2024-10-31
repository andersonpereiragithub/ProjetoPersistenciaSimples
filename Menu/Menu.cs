using ProjetoPersistenciaSimples.Models.Clientes;
using ProjetoPersistenciaSimples.Services;
using System;

public class Menu
{
    private readonly ClienteService _clienteService;
    private readonly ImovelService _imovelService;

    public Menu()
    {
        _clienteService = new ClienteService();
        _imovelService = new ImovelService();
    }

    public void ExibirMenu()
    {
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("\n--- Menu Principal ---");
            Console.WriteLine("1. Cadastrar Pessoa Física");
            Console.WriteLine("2. Cadastrar Pessoa Jurídica");
            Console.WriteLine("3. Cadastrar Imóvel");
            Console.WriteLine("4. Listar Clientes");
            Console.WriteLine("5. Listar Imóveis");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CadastrarPessoaFisica();
                    break;
                case "2":
                    CadastrarPessoaJuridica();
                    break;
                case "3":
                    CadastrarImovel();
                    break;
                case "4":
                    ListarClientes();
                    break;
                case "5":
                    ListarImoveis();
                    break;
                case "6":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }

    private void CadastrarPessoaFisica()
    {
        Console.WriteLine("\n--- Cadastro de Pessoa Física ---");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("CPF: ");
        string cpf = Console.ReadLine();

        var pessoaFisica = new PessoaFisica
        {
            Id = _clienteService.ObterClientes().Count + 1,
            Nome = nome,
            CPF = cpf
        };

        _clienteService.CadastrarCliente(pessoaFisica);
        Console.WriteLine("Pessoa Física cadastrada com sucesso.");
    }

    private void CadastrarPessoaJuridica()
    {
        Console.WriteLine("\n--- Cadastro de Pessoa Jurídica ---");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("CNPJ: ");
        string cnpj = Console.ReadLine();

        var pessoaJuridica = new PessoaJuridica
        {
            Id = _clienteService.ObterClientes().Count + 1,
            Nome = nome,
            CNPJ = cnpj
        };

        _clienteService.CadastrarCliente(pessoaJuridica);
        Console.WriteLine("Pessoa Jurídica cadastrada com sucesso.");
    }

    private void CadastrarImovel()
    {
        Console.WriteLine("\n--- Cadastro de Imóvel ---");
        Console.Write("Endereço: ");
        string endereco = Console.ReadLine();
        Console.Write("Inscrição IPTU: ");
        string inscricaoIPTU = Console.ReadLine();

        Console.WriteLine("Escolha o proprietário (ID):");
        ListarClientes();

        Console.Write("Digite o ID do proprietário: ");
        int proprietarioId = int.Parse(Console.ReadLine() ?? "0");

        var proprietario = _clienteService.ObterClientes().Find(c => c.Id == proprietarioId);
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

    private void ListarClientes()
    {
        var clientes = _clienteService.ObterClientes();
        Console.WriteLine("\n--- Clientes Cadastrados ---");
        foreach (var cliente in clientes)
        {
            if (cliente is PessoaFisica pf)
                Console.WriteLine($"ID: {pf.Id}, Nome: {pf.Nome}, CPF: {pf.CPF}");
            else if (cliente is PessoaJuridica pj)
                Console.WriteLine($"ID: {pj.Id}, Nome: {pj.Nome}, CNPJ: {pj.CNPJ}");
        }
    }

    private void ListarImoveis()
    {
        var imoveis = _imovelService.ObterImoveis();
        Console.WriteLine("\n--- Imóveis Cadastrados ---");
        foreach (var imovel in imoveis)
        {
            Console.WriteLine($"ID: {imovel.Id}, Endereço: {imovel.Endereco}, Inscrição IPTU: {imovel.InscricaoIPTU}, Proprietário: {imovel.Proprietario.Nome}");
        }
    }
}
