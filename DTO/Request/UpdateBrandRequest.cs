using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;

namespace CQRSMediatRAutoMaperTask.DTO.Request
{
    public class UpdateBrandRequest : IRequest<UpdateBrandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
