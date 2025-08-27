using MediatR;
using poroject_777.src.BusinessLogic.BusinessSearch.Models;

namespace poroject_777.src.BusinessLogic.BusinessManage.Comands
{
    public record BusinessUpdateCommand(Business business): IRequest<bool>
    {
    }
}
