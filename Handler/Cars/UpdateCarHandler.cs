using AutoMapper;
using CQRSMediatRAutoMaperTask.DAL;
using CQRSMediatRAutoMaperTask.DTO.Request;
using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatRAutoMaperTask.Handler.Cars
{
    public class UpdateCarHandler : IRequestHandler<UpdateCarRequest, UpdateCarResponse>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public UpdateCarHandler(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UpdateCarResponse> Handle(UpdateCarRequest request, CancellationToken cancellationToken)
        {
            if (!_context.Cars.Any(c => c.Id == request.Id))
            {
                throw new Exception("There is no car matching this id");
            }
            var car = _context.Cars.Find(request.Id);
            _mapper.Map(request, car);
            await _context.SaveChangesAsync();
            var response = _mapper.Map<UpdateCarResponse>(car);
            return response;
        }
    }
}
