using MediatR;
using Microsoft.AspNetCore.Mvc;
using poroject_777.BusinessLogic.BusinessSearch.Models;
using poroject_777.BusinessLogic.BusinessSearch.Queries;

namespace poroject_777.WebApp.Controllers
{

    [ApiController]
    [Route("business")]
    public class BusinessContoroller : ControllerBase
    {
        private readonly IMediator mediator;
        public BusinessContoroller(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> Get(CancellationToken cancellationToken)
        {
            var businesses = await mediator.Send(new BusinessQuery(), cancellationToken);
            return Ok(businesses);
        }
    }
}
