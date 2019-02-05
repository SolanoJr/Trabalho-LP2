using System;
using System.Collections.Generic;
using System.Text;

namespace Atividade2EFCoreClassLibrary
{
    public class Agencia
    {
        public int Id { get; set; }
        public int Numero { get; set; }

        public int BancoId { get; set; }
        public virtual Banco Banco { get; set; }
    }
}
