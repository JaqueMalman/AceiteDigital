using AceiteDigitalApp.Domain.Entities;
using AceiteDigitalApp.Domain.Interfaces;
using MediatR;

namespace AceiteDigital.Application.Documentos.Commands.CriarDocumento
{
    public class CriarDocumentoCommand : IRequest<Documento>
    {
        public string Titulo { get; set; }

        public string Descricao { get; set; }
    }

    public class CriarDocumentoCommandHandler :
        IRequestHandler<CriarDocumentoCommand, Documento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarDocumentoCommandHandler(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<Documento> Handle(
            CriarDocumentoCommand request, 
            CancellationToken cancellationToken)
        {
            var documentoInserir = new Documento(
                 request.Titulo,
                 request.Descricao);

            var repositoryDocumento =
                _unitOfWork.GetRepository<Documento>();

            repositoryDocumento.Add(documentoInserir);

            await _unitOfWork.CommitAsync();

            return documentoInserir;
        }
    }
}
