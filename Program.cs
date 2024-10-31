using ProjetoPersistenciaSimples.Models.Clientes;
using ProjetoPersistenciaSimples.Models;
using ProjetoPersistenciaSimples.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //// Instancia os serviços
        //var clienteService = new ClienteService();
        //var imovelService = new ImovelService();

        //// Cria um cliente PessoaFisica e salva
        //var pessoaFisica = new PessoaFisica
        //{
        //    Id = 1,
        //    Nome = "Anderson Paiva",
        //    CPF = "007394880708"
        //};
        //clienteService.CadastrarCliente(pessoaFisica);
        //Console.WriteLine("Pessoa Física cadastrada com sucesso.");

        //// Cria um cliente PessoaJuridica e salva
        //var pessoaJuridica = new PessoaJuridica
        //{
        //    Id = 2,
        //    Nome = "Empresa EFG Ltda",
        //    CNPJ = "12.345.678/0000-01"
        //};
        //clienteService.CadastrarCliente(pessoaJuridica);
        //Console.WriteLine("Pessoa Jurídica cadastrada com sucesso.");

        //// Cria um imóvel com o proprietário sendo a PessoaFisica
        //var imovel = new Imovel
        //{
        //    Id = 1,
        //    Proprietario = pessoaFisica,
        //    Endereco = "Rua Paula Lima, 175",
        //    InscricaoIPTU = "IPTU123789"
        //};
        //imovelService.CadastrarImovel(imovel);
        //Console.WriteLine("Imóvel cadastrado com sucesso.");

        //// Exibe todos os clientes cadastrados
        //var clientes = clienteService.ObterClientes();
        //Console.WriteLine("\nClientes cadastrados:");
        //foreach (var cliente in clientes)
        //{
        //    if (cliente is PessoaFisica pf)
        //        Console.WriteLine($"ID: {pf.Id}, Nome: {pf.Nome}, CPF: {pf.CPF}");
        //    else if (cliente is PessoaJuridica pj)
        //        Console.WriteLine($"ID: {pj.Id}, Nome: {pj.Nome}, CNPJ: {pj.CNPJ}");
        //}

        //// Exibe todos os imóveis cadastrados
        //var imoveis = imovelService.ObterImoveis();
        //Console.WriteLine("\nImóveis cadastrados:");
        //foreach (var im in imoveis)
        //{
        //    Console.WriteLine($"ID: {im.Id}, Endereço: {im.Endereco}, Inscrição IPTU: {im.InscricaoIPTU}, Proprietário: {im.Proprietario.Nome}");
        //}
        //Console.ReadKey();
    }
}
