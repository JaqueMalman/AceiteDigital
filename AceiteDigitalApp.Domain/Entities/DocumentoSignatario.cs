namespace AceiteDigitalApp.Domain.Entities
{
    public class DocumentoSignatario : BaseEntity
    {
        public DocumentoSignatario(Signatario signatario, TipoSignatario tipoSignatario)
        {
            SignatarioId = signatario.Id;
            Signatario = signatario;
            TipoSignatario = tipoSignatario;
        }

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

        public void Assinar()
        {
            if (Assinatura == null)
            {
                Assinatura = new Assinatura();
            }
            
            Assinatura.Assinar();
        }

        public void RecusarAssinatura()
        {
            if (Assinatura == null)
            {
                Assinatura = new Assinatura();
            }

            Assinatura.RecusarAssinatura();
        }
    }
}