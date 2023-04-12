using AutoMapper;
using CQRSMediatRAutoMaperTask.DAL;
using CQRSMediatRAutoMaperTask.DTO.Request;
using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatRAutoMaperTask.Handler.Cars
{
    public class GetCarByBrandIdHandler : IRequestHandler<GetCarByBrandIdRequest, List<GetCarByBrandIdResponse>>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public GetCarByBrandIdHandler(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<List<GetCarByBrandIdResponse>> Handle(GetCarByBrandIdRequest request, CancellationToken cancellationToken)
        {
            if (!_context.Cars.Any(c => c.BrandId == request.Id))
            {
                throw new Exception("There is no brand matching this id");
            }
            var model = _context.Cars.Include(c => c.Brand).Where(c => c.BrandId == request.Id).ToList();
            var result = _mapper.Map<List<GetCarByBrandIdResponse>>(model);
            return Task.FromResult(result);
        }
    }
}
