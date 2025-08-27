using MediatR;
using poroject_777.src.BusinessLogic.BusinessManage.Models;

namespace poroject_777.src.BusinessLogic.BusinessManage.Comands
{
    public record BusinessCreateCommand(BusinessDTO businessDTO): IRequest<bool>
    {
    }
}
