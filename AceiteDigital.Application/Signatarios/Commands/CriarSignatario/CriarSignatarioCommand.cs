using AceiteDigitalApp.Domain.Entities;
using AceiteDigitalApp.Domain.Interfaces;
using MediatR;

namespace AceiteDigital.Application.Signatarios.Commands.CriarSignatario
{
    public class CriarSignatarioCommand : IRequest<Signatario>
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
    }

    public class CriarSignatarioCommandHandler : IRequestHandler<CriarSignatarioCommand, Signatario>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarSignatarioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Signatario> Handle(
            CriarSignatarioCommand request,
            CancellationToken cancellationToken)
        {
            var signatarioInserir = new Signatario(request.Cpf, request.Nome, request.Email);

            var repositorySinatario =
                _unitOfWork.GetRepository<Signatario>();

            repositorySinatario.Add(signatarioInserir);

            await _unitOfWork.CommitAsync();

            return signatarioInserir;
        }
    }
}