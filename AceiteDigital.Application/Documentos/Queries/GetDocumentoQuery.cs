using AceiteDigitalApp.Domain.Entities;
using AceiteDigitalApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AceiteDigital.Application.Documentos.Queries
{
    public class GetDocumentoQuery : IRequest<Documento>
    {
        public long DocumentoId    { get; set; }
    }

    public class GetDocumentoQueryHandler : IRequestHandler<GetDocumentoQuery, Documento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDocumentoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Documento> Handle(GetDocumentoQuery request, CancellationToken cancellationToken)
        {
            var repositoryDocumento = _unitOfWork.GetRepository<Documento>();
            var documento = await repositoryDocumento
                .FindBy(d => d.Id == request.DocumentoId)
                .Include(d => d.DocumentosSignatarios).ThenInclude(s => s.Assinatura)
                .FirstAsync(cancellationToken);

            return documento;
        }
    }
}
