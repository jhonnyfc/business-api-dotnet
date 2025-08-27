using MediatR;
using poroject_777.src.BusinessLogic.BusinessSearch.Models;

namespace poroject_777.src.BusinessLogic.BusinessSearch.Queries
{
    public record BusinessQuery(): IRequest<IEnumerable<Business>>
    {
    }
}
