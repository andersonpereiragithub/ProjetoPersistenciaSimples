using ProjetoPersistenciaSimples.Models.Clientes;
using ProjetoPersistenciaSimples.Services;
using System.Collections.Generic;
using System;

public class ClienteController
{
    private readonly ClienteService _clienteService;

    public ClienteController()
    {
        _clienteService = new ClienteService();
    }

    public void CadastrarPessoaFisica(string nome, string cpf)
    {
        var pessoaFisica = new PessoaFisica
        {
            Id = _clienteService.ObterClientes().Count + 1,
            Nome = nome,
            CPF = cpf
        };
        _clienteService.CadastrarCliente(pessoaFisica);
        Console.WriteLine("Pessoa Física cadastrada com sucesso.");
    }

    public void CadastrarPessoaJuridica(string nome, string cnpj)
    {
        var pessoaJuridica = new PessoaJuridica
        {
            Id = _clienteService.ObterClientes().Count + 1,
            Nome = nome,
            CNPJ = cnpj
        };
        _clienteService.CadastrarCliente(pessoaJuridica);
        Console.WriteLine("Pessoa Jurídica cadastrada com sucesso.");
    }

    public List<Cliente> ListarClientes()
    {
        return _clienteService.ObterClientes();
    }
}