using AutoMapper;
using CQRSMediatRAutoMaperTask.DAL;
using CQRSMediatRAutoMaperTask.DTO.Request;
using CQRSMediatRAutoMaperTask.DTO.Response;
using CQRSMediatRAutoMaperTask.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatRAutoMaperTask.Handler.Cars
{
    public class CreateCarHandler : IRequestHandler<CreateCarRequest, CreateCarResponse>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public CreateCarHandler(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CreateCarResponse> Handle(CreateCarRequest request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            var response = _mapper.Map<CreateCarResponse>(car);
            return response;
        }
    }
}
