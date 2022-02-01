namespace AceiteDigitalApp.Domain.Entities
{
    public class Signatario : BaseEntity
    {
        public Signatario(string cpf, string nome, string email)
        {
            Cpf = cpf;
            Nome = nome;
            Email = email;
        }

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
