using AutoMapper;
using LMS.Application.Features.LookupDetails.Commands;
using LMS.Application.Features.LookupDetails.Queries;
using LMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LookupDetailController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _mediator.Send(new GetAllLookupDetailsQuery());
            return Ok(list);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            var entity = await _mediator.Send(new GetLookupDetailByIdQuery(id));
            return Ok(entity);
        }
        [HttpPost("Create")]
        public async Task<ActionResult> Create(CreateLookupDetailsCommand lookupDetail)
        {
            await _mediator.Send(lookupDetail);
            return Created($"/LookupDetail/GetById?id={lookupDetail.Id}", lookupDetail);
        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateLookupDetailsCommand lookupDetail)
        {
            await _mediator.Send(lookupDetail);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _mediator.Send(new DeleteLookupDetailsCommand(id));
            return Ok(res);
        }
    }
}
