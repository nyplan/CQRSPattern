using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;

namespace CQRSMediatRAutoMaperTask.DTO.Request
{
    public class DeleteBrandRequest : IRequest<DeleteBrandResponse>
    {
        public int Id { get; set; }
    }
}
