using AutoMapper;
using CQRSMediatRAutoMaperTask.DAL;
using CQRSMediatRAutoMaperTask.DTO.Request;
using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatRAutoMaperTask.Handler
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandRequest, DeleteBrandResponse>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public DeleteBrandHandler(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<DeleteBrandResponse> Handle(DeleteBrandRequest request, CancellationToken cancellationToken)
        {
            if (!_context.Brands.Any(c=>c.Id == request.Id))
            {
                throw new Exception("There is no brand matching this id");
            }
            var brand = _context.Brands.Find(request.Id);
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            var result = _mapper.Map<DeleteBrandResponse>(brand);
            return Task.FromResult(result);
        }
    }
}
