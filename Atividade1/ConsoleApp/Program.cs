using Atividade1POO;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o titular:");
            var titular = Convert.ToString(Console.ReadLine());

            DateTime dateTime = DateTime.Now;
            ContaPoupanca contaPoupanca = new ContaPoupanca(0.1M, dateTime, titular);

            ContaCorrente contaCorrente = new ContaCorrente(titular);

            while (true)
            {
                Console.WriteLine("Digite um Número para acessar: ");
                Console.WriteLine("1 - Conta Poupança (cp)");
                Console.WriteLine("2 - Conta Corrente (cc)");
                Console.WriteLine("0 - Sair");

                var tipoConta = Convert.ToInt16(Console.ReadLine());
          
                if (tipoConta == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("1 - Sacar");
                        Console.WriteLine("2 - Depositar");
                        Console.WriteLine("3 - Saldo");
                        Console.WriteLine("0 - Voltar");

                        var operacao = Convert.ToInt16(Console.ReadLine());

                        if (operacao == 1)
                        {
                            Console.WriteLine("Digite o valor:");
                            var valor = Convert.ToInt16(Console.ReadLine());
                            contaPoupanca.Sacar(valor);
                        }
                        else if (operacao == 2)
                        {
                            Console.WriteLine("Digite o valor:");
                            var valor = Convert.ToInt16(Console.ReadLine());
                            contaPoupanca.Depositar(valor);
                        }
                        else if (operacao == 3)
                        {
                            Console.WriteLine($"Titular: {contaPoupanca.Id} / Saldo: {contaPoupanca.Saldo}");
                        }
                        else if (operacao == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Número inválido");
                        }
                    }
                }
                else if (tipoConta == 2)
                {
                    while (true)
                    {
                        Console.WriteLine("1 - Sacar");
                        Console.WriteLine("2 - Depositar");
                        Console.WriteLine("3 - Saldo");
                        Console.WriteLine("0 - Sair");

                        var operacao = Convert.ToInt16(Console.ReadLine());

                        if (operacao == 1)
                        {
                            Console.WriteLine("Digite o valor:");
                            var valor = Convert.ToInt16(Console.ReadLine());
                            contaCorrente.Sacar(valor);
                        }
                        else if (operacao == 2)
                        {
                            Console.WriteLine("Digite o valor:");
                            var valor = Convert.ToInt16(Console.ReadLine());
                            contaCorrente.Depositar(valor);
                        }
                        else if (operacao == 3)
                        {
                            Console.WriteLine($"Titular: {contaCorrente.Id} / Saldo: {contaCorrente.Saldo}");
                        }
                        else if (operacao == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Número inválido");
                        }
                    }
                }
                else if(tipoConta == 0)
                {
                    return;  
                }
                else
                {
                    Console.WriteLine("Número inválido.");
                }
            }
        }
    }
}
