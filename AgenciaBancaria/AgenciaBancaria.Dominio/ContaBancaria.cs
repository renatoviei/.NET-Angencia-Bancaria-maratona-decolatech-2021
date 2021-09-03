using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AgenciaBancaria.Dominio
{
    //Classe abstrata para garanti que não pode ser instanciada
    public abstract class ContaBancaria
    {
        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();
            NumeroConta = random.Next(50000, 100000);
            DigitoVerificador = random.Next(0, 9);

            Situacao = SituacaoConta.Criada;

            Cliente = cliente ?? throw new Exception("Cliente deve ser informado.");
        }

        public void Abrir(string senha)
        {
            SetaSenha(senha);

            Situacao = SituacaoConta.Aberta;
            DataAbertura = DateTime.Now;
        }

        private void SetaSenha(string senha)
        {
            senha = senha.ValidaStringVazia();

            //Expressão rgular para validar a senha (8 caracteres, pelo menos uma 1 letra e 1 número)
            if(!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))
            {
                throw new Exception("Senha inválida!");
            }
        }

        //Notação VIRTUAL indicando que o comportamento do método será sobrescrito (mudado) na classe filha
        public virtual void Sacar(decimal valor, string senha)
        {
            if (Senha != senha)
            {
                throw new Exception("Senha inválida");
            }

            if(Saldo < valor)
            {
                throw new Exception("Saldo insuficiente");
            }

            Saldo -= valor;
        }

        public int NumeroConta { get; init; }

        public int DigitoVerificador { get; init; }

        public decimal Saldo { get; protected set; }

        public DateTime? DataAbertura { get; private set; }

        public DateTime? DataEncerramento { get; private set; }

        //Enumerador
        public SituacaoConta Situacao { get; private set; }

        public string Senha { get; private set; }

        public Cliente Cliente { get; init; }
    }
}
