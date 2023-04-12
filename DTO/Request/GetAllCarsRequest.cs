using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;
using System.Collections.Generic;

namespace CQRSMediatRAutoMaperTask.DTO.Request
{
    public class GetAllCarsRequest : IRequest<List<GetAllCarsResponse>>
    {
    }
}
