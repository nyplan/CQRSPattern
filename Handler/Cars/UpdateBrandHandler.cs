using AutoMapper;
using CQRSMediatRAutoMaperTask.DAL;
using CQRSMediatRAutoMaperTask.DTO.Request;
using CQRSMediatRAutoMaperTask.DTO.Response;
using CQRSMediatRAutoMaperTask.Model;
using MediatR;
using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatRAutoMaperTask.Handler.Cars
{
    public class UpdateBrandHandler : IRequestHandler<UpdateBrandRequest, UpdateBrandResponse>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public UpdateBrandHandler(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateBrandResponse> Handle(UpdateBrandRequest request, CancellationToken cancellationToken)
        {
            if (_context.Brands.Any(c => c.Id == request.Id))
            {
                throw new Exception("There is no brand matching this id");
            }
            var brand = _context.Brands.Find(request.Id);
            _mapper.Map(request, brand);
            await _context.SaveChangesAsync();
            var response = _mapper.Map<UpdateBrandResponse>(brand);
            return response;
        }
    }
}
