using CQRSMediatRAutoMaperTask.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using MediatR;
using CQRSMediatRAutoMaperTask.DTO.Request;
using System.Threading.Tasks;
using CQRSMediatRAutoMaperTask.DTO.Response;
using System;

namespace CQRSMediatRAutoMaperTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMediator _mediatr;
        public CarController(ApiContext context, IMediator mediator)
        {
            _context = context;
            _mediatr = mediator;
        }

        [HttpGet("GetCarsByBrandId")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetCarByBrandIdRequest() { Id = id };
            return Ok(await _mediatr.Send(query));
        }
        [HttpGet("GetAllCars")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllCarsRequest();
            return Ok(await _mediatr.Send(query));
        }

        [HttpPost("PostCar")]
        public async Task<ActionResult<CreateCarResponse>> Post([FromQuery]CreateCarRequest request)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);
        }
        [HttpPost("PostBrand")]
        public async Task<ActionResult<CreateBrandResponse>> Post([FromQuery] CreateBrandRequest request)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);
        }
        [HttpDelete("DeleteCar")]
        public async Task<ActionResult<DeleteCarResponse>> Delete([FromQuery] DeleteCarRequest request)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);
        }
        [HttpDelete("DeleteBrand")]
        public async Task<ActionResult<DeleteBrandResponse>> Delete([FromQuery] DeleteBrandRequest request)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);
        }
        [HttpPut("UpdateCar")]
        public async Task<ActionResult<UpdateCarResponse>> Put([FromQuery] UpdateCarRequest request)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);
        }
        [HttpPut("UpdateBrand")]
        public async Task<ActionResult<UpdateBrandResponse>> Put([FromQuery] UpdateBrandRequest request)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);
        }

    }
}
