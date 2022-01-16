using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceiteDigitalApp.Domain.Entities
{
    public class Signatario : BaseEntity
    {
        private Signatario()
        { 
            //utilizado pelo EF
        }

        public string Cpf { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        private readonly List<DocumentoSignatario> _documentosSignatarios = new();
        public IReadOnlyCollection<DocumentoSignatario> DocumentosSignatarios =>
            _documentosSignatarios.AsReadOnly();
    }
}
