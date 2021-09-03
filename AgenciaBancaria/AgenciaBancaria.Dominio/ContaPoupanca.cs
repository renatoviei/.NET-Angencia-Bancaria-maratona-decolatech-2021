using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaBancaria.Dominio
{
    //ContaPoupanca herda de ContaBancaria
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(Cliente cliente) : base(cliente)
        {
            //0,30% ao mês de rendimento da poupança
            PercentualRendimento = 0.003M;
        }

        public decimal PercentualRendimento { get; private set; }
    }
}
