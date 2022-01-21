using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceiteDigitalApp.Domain.Entities
{
    public class Assinatura : BaseEntity
    {
        private Assinatura()
        { 
            //utilizado pelo EF
        }

        public long DocumentoSignatarioId { get; private set; }

        public bool Assinado { get; private set; }

        public DateTime DataHoraRegistro { get; private set; }

        public DocumentoSignatario DocumentoSignatario { get; private set; }


    }
}
