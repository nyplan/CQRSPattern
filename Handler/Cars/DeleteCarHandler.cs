using AutoMapper;
using CQRSMediatRAutoMaperTask.DAL;
using CQRSMediatRAutoMaperTask.DTO.Request;
using CQRSMediatRAutoMaperTask.DTO.Response;
using MediatR;
using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CQRSMediatRAutoMaperTask.Handler.Cars
{
    public class DeleteCarHandler : IRequestHandler<DeleteCarRequest, DeleteCarResponse>
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public DeleteCarHandler(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<DeleteCarResponse> Handle(DeleteCarRequest request, CancellationToken cancellationToken)
        {
            if (!_context.Cars.Any(c => c.Id == request.Id))
            {
                throw new Exception("There is no car matching this id");
            }
            var car = _context.Cars.Where(c => c.Id == request.Id).First();
            _context.Cars.Remove(car);
            _context.SaveChanges();
            var result = _mapper.Map<DeleteCarResponse>(car);
            return Task.FromResult(result);
        }
    }
}
