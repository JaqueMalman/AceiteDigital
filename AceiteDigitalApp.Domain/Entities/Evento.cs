namespace AceiteDigitalApp.Domain.Entities
{
    public class Evento : BaseEntity
    {
        private Evento()
        { 
            //utilizado EF
        }

        public DateTime DataHoraEvento { get; private set; }

        public string Descricao { get; private set;}

        public TipoEvento TipoEvento { get; private set; }

        public long DocumentoId { get; private set; }

        public  Documento Documento { get; private set; }
    }
}
