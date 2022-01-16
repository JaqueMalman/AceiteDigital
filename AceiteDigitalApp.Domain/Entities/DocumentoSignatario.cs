using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceiteDigitalApp.Domain.Entities
{
    public class DocumentoSignatario : BaseEntity
    {
        private DocumentoSignatario()
        { 
            // utilizado pelo EF
        }

        public long DocumentoId { get; private set; }

        public long SignatarioId { get; private set; }

        public TipoSignatario TipoSignatario { get; private set; }

        public Documento Documento { get; private set; }

        public Signatario Signatario { get; private set; }

        public Assinatura Assinatura { get ; private set; }

    }
}
