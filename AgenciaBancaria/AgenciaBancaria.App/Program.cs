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
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
