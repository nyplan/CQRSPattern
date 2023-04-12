using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;

namespace CQRSMediatRAutoMaperTask.DTO.Request
{
    public class CreateCarRequest : IRequest<CreateCarResponse>
    {
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
