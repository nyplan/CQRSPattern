using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;

namespace CQRSMediatRAutoMaperTask.DTO.Request
{
    public class UpdateCarRequest : IRequest<UpdateCarResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int BrandId { get; set; }
    }
}
