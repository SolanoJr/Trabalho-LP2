using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCoreClassLibrary
{
    public class ContaPoupanca : Conta
    {
        private decimal taxaJuros { get; set; }
        private DateTime dataAniversario { get; set; }

        public decimal Juros
        {
            get { return taxaJuros; }
            set { taxaJuros = value; }
        }

        public DateTime DataAniversario
        {
            get { return dataAniversario; }
        }

        public void AdicionarRendimento()
        {
            if (DateTime.Now.Equals(dataAniversario))
            {
                decimal rendimento;
                rendimento = Saldo * taxaJuros;
                Depositar(rendimento);
            }
        }
    }
}
