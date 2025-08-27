using MediatR;

namespace poroject_777.src.BusinessLogic.BusinessManage.Comands
{
    public record BusinessDeleteCommand(int id): IRequest<bool>
    {
    }
}
