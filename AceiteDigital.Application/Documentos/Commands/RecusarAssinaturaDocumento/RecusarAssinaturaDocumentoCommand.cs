using AceiteDigitalApp.Domain.Entities;
using AceiteDigitalApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceiteDigital.Application.Documentos.Commands.RecusarAssinaturaDocumento
{
    public class RecusarAssinaturaDocumentoCommand : IRequest
    {
        public long DocumentoId { get; set; }

        public long SignatarioId { get; set; }
    }

    public class RecusarAssinaturaDocumentoCommandHandler : IRequestHandler<RecusarAssinaturaDocumentoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecusarAssinaturaDocumentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            RecusarAssinaturaDocumentoCommand request,
            CancellationToken cancellationToken)
        {
            var repositoryDocumento = _unitOfWork.GetRepository<Documento>();
            var documento = await repositoryDocumento
               .FindBy(d => d.Id == request.DocumentoId)
               .Include(d => d.DocumentosSignatarios).ThenInclude(s => s.Assinatura)               
               .FirstAsync(cancellationToken);

            var repositorySigantario = _unitOfWork.GetRepository<Signatario>();
            var signatario = await repositorySigantario.GetByIdAsync(request.SignatarioId);

            documento.RecusarAssinaturaDocumento(signatario);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
