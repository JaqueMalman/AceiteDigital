using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
