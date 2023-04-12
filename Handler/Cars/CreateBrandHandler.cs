using AutoMapper;
using CQRSMediatRAutoMaperTask.DAL;
using CQRSMediatRAutoMaperTask.DTO.Request;
using CQRSMediatRAutoMaperTask.DTO.Response;
using CQRSMediatRAutoMaperTask.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatRAutoMaperTask.Handler.Cars
{
    public class CreateBrandHandler : IRequestHandler<CreateBrandRequest, CreateBrandResponse>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public CreateBrandHandler(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CreateBrandResponse> Handle(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request);
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            var response = _mapper.Map<CreateBrandResponse>(brand);
            return response;
        }
    }
}
