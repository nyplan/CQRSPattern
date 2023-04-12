using AutoMapper;
using CQRSMediatRAutoMaperTask.DAL;
using CQRSMediatRAutoMaperTask.DTO.Request;
using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatRAutoMaperTask.Handler.Cars
{
    public class GetAllCarsHandler : IRequestHandler<GetAllCarsRequest, List<GetAllCarsResponse>>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public GetAllCarsHandler(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<List<GetAllCarsResponse>> Handle(GetAllCarsRequest request, CancellationToken cancellationToken)
        {
            var model = _context.Cars.Include(c => c.Brand).ToList();
            var result = _mapper.Map<List<GetAllCarsResponse>>(model);
            return Task.FromResult(result);
        }
    }
}
