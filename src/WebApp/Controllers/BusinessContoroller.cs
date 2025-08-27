using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using poroject_777.src.BusinessLogic.BusinessManage.Comands;
using poroject_777.src.BusinessLogic.BusinessSearch.Queries;
using poroject_777.src.BusinessLogic.BusinessManage.Models;
using poroject_777.src.BusinessLogic.BusinessSearch.Models;

namespace poroject_777.src.WebApp.Controllers
{

    [ApiController]
    [Route("business")]
    public class BusinessContoroller : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<BusinessContoroller> logger;
    
        public BusinessContoroller(IMediator mediator, ILogger<BusinessContoroller> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> Get(CancellationToken cancellationToken)
        {
            logger.LogInformation("HTTP Get All Request initialized");
            var businesses = await mediator.Send(new BusinessQuery(), cancellationToken);
            return Ok(businesses);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Business>> GetById(int id, CancellationToken cancellationToken)
        {
            logger.LogInformation("HTTP Get business by id initialized: {id}", id);
            var business = await mediator.Send(new BusinessByIdQuery(id), cancellationToken);
            return Ok(business);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BusinessDTO businessDTO, CancellationToken cancellationToken)
        {
            logger.LogInformation("HTTP Ceate business initialized: {ObjectJson}", JsonSerializer.Serialize(businessDTO, new JsonSerializerOptions { WriteIndented = true }));
            var result = await mediator.Send(new BusinessCreateCommand(businessDTO), cancellationToken);
            return result ? Ok() : StatusCode(500, "Failed to create genre");
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Business business, CancellationToken cancellationToken)
        {
            logger.LogInformation("HTTP Update business initialized: {ObjectJson} ", JsonSerializer.Serialize(business, new JsonSerializerOptions { WriteIndented = true }) );
            var result = await mediator.Send(new BusinessUpdateCommand(business), cancellationToken);
            return result ? Ok() : StatusCode(500, "Failed to update genre");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            logger.LogInformation("HTTP Delete business by id initialized: {id}", id);
            var result = await mediator.Send(new BusinessDeleteCommand(id), cancellationToken);
            return result ? Ok() : StatusCode(500, "Failed to delete genre");
        }   
    }
}
