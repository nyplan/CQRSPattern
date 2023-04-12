using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;

namespace CQRSMediatRAutoMaperTask.DTO.Request
{
    public class DeleteCarRequest : IRequest<DeleteCarResponse>
    {
        public int Id { get; set; }
    }
}
