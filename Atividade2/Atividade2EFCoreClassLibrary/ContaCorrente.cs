using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCoreClassLibrary
{
    public class ContaCorrente : Conta
    {
        public const decimal Taxa = 0.10M;

        public override void Depositar(decimal valor)
        {
            decimal desconto = valor * Taxa;
            base.Depositar(valor - desconto);
        }

        public override void Sacar(decimal valor)
        {
            decimal desconto = valor * Taxa;
            base.Sacar(valor + desconto);
        }
    }
}
