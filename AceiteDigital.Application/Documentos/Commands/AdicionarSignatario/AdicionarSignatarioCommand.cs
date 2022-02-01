using AceiteDigitalApp.Domain.Entities;
using AceiteDigitalApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AceiteDigital.Application.Documentos.Commands.AdicionarSignatario
{
    public class AdicionarSignatarioCommand : IRequest
    { 
        public long DocumentoId { get; set; }

        public long SignatarioId { get; set; }
        /// <summary>
        /// P para parte
        /// T para testemunha
        /// </summary>
        public char TipoSignatario { get; set; }
    }

    public class AdicionarSignatarioCommandHandler : IRequestHandler<AdicionarSignatarioCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdicionarSignatarioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AdicionarSignatarioCommand request, 
            CancellationToken cancellationToken)
        {
            var repositoryDocumento = _unitOfWork.GetRepository<Documento>();
            var documento = await repositoryDocumento
                .FindBy(d => d.Id == request.DocumentoId)
                .Include(d => d.DocumentosSignatarios)
                .FirstAsync(cancellationToken);

            var repositorySignatario = _unitOfWork.GetRepository<Signatario>();
            var signatario = await repositorySignatario.GetByIdAsync(request.SignatarioId);

            var tipoSignatario = request.TipoSignatario == 'P' ? 
                TipoSignatario.Parte : TipoSignatario.Testemunha;

            documento.AdicionarSignatario(signatario, tipoSignatario);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
