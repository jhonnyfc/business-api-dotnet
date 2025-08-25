using MediatR;
using poroject_777.BusinessLogic.BusinessSearch.Models;

namespace poroject_777.BusinessLogic.BusinessSearch.Queries
{
    public record BusinessQuery(): IRequest<IEnumerable<Business>>
    {
    }
}
