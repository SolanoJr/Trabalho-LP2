using Atividade2EFCoreClassLibrary;
using Atividade2EFCoreClassLibrary.Models;
using System;
using System.Linq;

namespace Atividade2EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StoreContext())
            {
                context.Set<Agencia>().RemoveRange(context.Agencias);
                context.Set<Banco>().RemoveRange(context.Bancos);
                context.Set<Cliente>().RemoveRange(context.Clientes);
                context.Set<ClienteSolicitacao>().RemoveRange(context.ClienteSolicitacoes);
                context.Set<Conta>().RemoveRange(context.Contas);
                context.Set<ContaCorrente>().RemoveRange(context.ContasCorrente);
                context.Set<ContaPoupanca>().RemoveRange(context.ContasPoupanca);
                context.Set<Solicitacao>().RemoveRange(context.Solicitacoes);

                #region Objetos
                
                var bancoDoBrasil = new Banco() { Nome = "Banco do Brasil" };
                var bancoCaixa = new Banco() { Nome = "Caixa Econômica" };

                context.Add(bancoDoBrasil);
                context.Add(bancoCaixa);
                context.SaveChanges();

                var agenciaBancoBrasil = new Agencia() { Numero = 1001, BancoId = bancoDoBrasil.Id };
                var agenciaCaixa = new Agencia() { Numero = 1002, BancoId = bancoCaixa.Id };

                context.Add(agenciaBancoBrasil);
                context.Add(agenciaCaixa);
                context.SaveChanges();

                #endregion

                while (true)
                {
                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1 - Adicionar cliente");
                    Console.WriteLine("2 - Exibir clientes cadastrados");
                    Console.WriteLine("3 - Atualizar nome de um cliente");
                    Console.WriteLine("4 - Excluir um cliente");
                    Console.WriteLine("0 - Sair");

                    var opcao = Convert.ToInt16(Console.ReadLine());

                    if(opcao == 1)
                    {
                        Console.WriteLine("Informe o nome do cliente:");
                        var nome = Console.ReadLine();
                        var cliente = new Cliente() { Nome = nome};
                        context.Add(cliente);
                        context.SaveChanges();
                    }
                    else if(opcao == 2)
                    {
                        var clientes = context.Set<Cliente>();
                        foreach (var c in clientes)
                        {
                            Console.WriteLine($"Cliente:\t{c.Nome}");
                        }
                    }
                    else if (opcao == 3)
                    {
                        Console.WriteLine("Informe o nome atual do cliente:");
                        var nomeVelho = Console.ReadLine();

                        Console.WriteLine("Informe o novo nome do cliente:");
                        var nomeNovo = Console.ReadLine();

                        var busca = context.Set<Cliente>().First(c => c.Nome.Equals(nomeVelho));

                        busca.Nome = nomeNovo;
                        context.SaveChanges();
                    }
                    else if (opcao == 4)
                    {
                        Console.WriteLine("Informe o nome atual do cliente:");
                        var nome = Console.ReadLine();

                        var busca = context.Set<Cliente>().First(c => c.Nome == nome);
                        context.Remove(busca);
                        context.SaveChanges();
                    }
                    else if(opcao == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida, digite novamente!");
                    }
                }
            }
        }
    }
}
