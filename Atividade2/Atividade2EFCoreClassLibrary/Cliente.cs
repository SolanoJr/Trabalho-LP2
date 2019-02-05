using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Atividade2EFCoreClassLibrary
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteSolicitacoes = new List<ClienteSolicitacao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual Conta Conta { get; set; }

        public virtual ICollection<ClienteSolicitacao> ClienteSolicitacoes { get; set; }
    }
}
