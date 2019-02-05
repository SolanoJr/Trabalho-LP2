using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCoreClassLibrary
{
    public class ClienteSolicitacao
    {
        public int ClienteId { get; set; }
        public int SolicitacaoId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Solicitacao Solicitacao { get; set; }
    }
}
