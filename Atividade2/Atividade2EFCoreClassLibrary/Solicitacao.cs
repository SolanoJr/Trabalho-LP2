using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Atividade2EFCoreClassLibrary
{
    public class Solicitacao
    {
        public Solicitacao()
        {
            ClienteSolicitacoes = new List<ClienteSolicitacao>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string Text { get; set; }

        public int AgenciaId { get; set; }
        public virtual Agencia Agencia { get; set; }

        public virtual ICollection<ClienteSolicitacao> ClienteSolicitacoes { get; set; }
    }
}
