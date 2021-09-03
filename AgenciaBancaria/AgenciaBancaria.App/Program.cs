using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereco endereco = new Endereco("Rua Araguaia", "11111222", "Recife", "Pernambuco");
                Cliente cliente = new Cliente("Renato", "12345678900", "7654321", endereco);

                ContaCorrente conta = new ContaCorrente(cliente, 100);

                Console.WriteLine("Conta " + conta.Situacao + ": " + conta.NumeroConta + conta.DigitoVerificador);

                string senha = "abcd1234";
                conta.Abrir(senha);

                Console.WriteLine("Conta " + conta.Situacao + ": " + conta.NumeroConta + conta.DigitoVerificador);

                conta.Sacar(10, senha);
                
                Console.WriteLine("Saldo: " + conta.Saldo);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
