using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;
using System.Collections.Generic;

namespace CQRSMediatRAutoMaperTask.DTO.Request
{
    public class GetCarByBrandIdRequest: IRequest<List<GetCarByBrandIdResponse>>
    {
        public int Id { get; set; }
    }
}
