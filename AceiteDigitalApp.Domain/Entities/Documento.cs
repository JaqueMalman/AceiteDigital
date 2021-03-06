namespace AceiteDigitalApp.Domain.Entities
{
    public class Documento : BaseEntity
    {
        public Documento(string titulo, string descricao)
        { 
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = DateTime.Now;
        }

        private Documento()
        { 
            //Necessário para entity framework
        }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public DateTime DataCriacao { get; private set; }

        private readonly List<Evento> _eventos = new ();
        public IReadOnlyCollection<Evento> Eventos => 
            _eventos.AsReadOnly();

        private readonly List<DocumentoSignatario> _documentosSignatarios = new ();
        public IReadOnlyCollection<DocumentoSignatario> DocumentosSignatarios =>
            _documentosSignatarios.AsReadOnly();

        public void AdicionarSignatario(Signatario signatario, TipoSignatario tipoSignatario)
        {
            var documentoSignatario = new DocumentoSignatario(signatario, tipoSignatario);

            _documentosSignatarios.Add(documentoSignatario);
        }

        public void AssinarDocumento(Signatario signatario)
        {
            var documentoSignatario = _documentosSignatarios.Find(d => d.SignatarioId == signatario.Id);
            if (documentoSignatario == null)
            {
                throw new Exception("Signatario não encontrado.");
            }

            documentoSignatario.Assinar();
        }

        public void RecusarAssinaturaDocumento(Signatario signatario)
        {
            var documentoSignatario = _documentosSignatarios.Find(d => d.SignatarioId == signatario.Id);
            if (documentoSignatario == null)
            {
                throw new Exception("Signatario não encontrado.");
            }

            documentoSignatario.RecusarAssinatura();
        }


    }
}
