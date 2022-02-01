using AceiteDigitalApp.Domain.Entities;
using AceiteDigitalApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AceiteDigital.Application.Signatarios.Queries
{
    public class GetSignatariosQuery :
          IRequest<List<Signatario>>
    {

    }

    public class GetSignatariosQueryHandler :
        IRequestHandler<GetSignatariosQuery, List<Signatario>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSignatariosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Signatario>> Handle(
            GetSignatariosQuery request,
            CancellationToken cancellationToken)
        {
            var repositorySigantario =
                _unitOfWork.GetRepository<Signatario>();

            var signatarios = await repositorySigantario
                .GetAll()
                .ToListAsync(cancellationToken);

            return signatarios;
        }
    }
}