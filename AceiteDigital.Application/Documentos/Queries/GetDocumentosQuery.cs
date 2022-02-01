using AceiteDigitalApp.Domain.Entities;
using AceiteDigitalApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace AceiteDigital.Application.Documentos.Queries
{
    public class GetDocumentosQuery : IRequest<List<Documento>>
    {
        ///public string Titulo { get; set; }
    }

    public class GetDocumentosQueryHandler :
        IRequestHandler<GetDocumentosQuery, List<Documento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDocumentosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Documento>> Handle(
            GetDocumentosQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryDocumento =
                _unitOfWork.GetRepository<Documento>();

            var documentos = await repositoryDocumento
                .GetAll()
            //    .Where(d => d.Titulo.Contains(request.Titulo))
                .ToListAsync(cancellationToken);

            return documentos;            
        }
    }
}
