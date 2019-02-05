using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade2EFCoreClassLibrary
{
    public class Conta
    {
        public int Id { get; set; }
        private decimal saldo;
        private string titular;
        public int ClienteId { get; set; }
        public int AgenciaId { get; set; }
        public virtual Agencia Agencia { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }

        public Conta()
        {
            Clientes = new List<Cliente>();
        }

        public decimal Saldo
        {
            get { return saldo; }
        }

        [StringLength(50)]
        public string Titular
        {
            get { return titular; }
        }

        public virtual void Depositar(decimal valor)
        {
            saldo += valor;
        }

        public virtual void Sacar(decimal valor)
        {
            if (valor <= saldo)
            {
                saldo -= valor;
            }
        }
    }
}
