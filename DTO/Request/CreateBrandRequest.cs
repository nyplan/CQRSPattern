using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;

namespace CQRSMediatRAutoMaperTask.DTO.Request
{
    public class CreateBrandRequest : IRequest<CreateBrandResponse>
    {
        public string Name { get; set; }
    }
}
