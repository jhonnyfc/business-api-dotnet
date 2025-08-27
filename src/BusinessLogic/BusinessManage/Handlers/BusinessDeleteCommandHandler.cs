using MediatR;
using poroject_777.src.BusinessLogic.BusinessManage.Comands;
using poroject_777.src.BusinessLogic.BusinessSearch.Models;
using poroject_777.src.DataAccess;
using poroject_777.src.DataAccess.Repositories;

namespace poroject_777.src.BusinessLogic.BusinessManage.Handlers
{
    public class BusinessDeleteCommandHandler : IRequestHandler<BusinessDeleteCommand, bool>
    {
        private GenericRepository<Business> BusinessRepository;

        public BusinessDeleteCommandHandler(DataContext dataContext)
        {
            BusinessRepository = new GenericRepository<Business>(dataContext);
        }

        public Task<bool> Handle(BusinessDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BusinessRepository.DeleteAsync(request.id, cancellationToken).Wait(cancellationToken);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting business: {ex.Message}");
                return Task.FromResult(false);
            }
        }
    }
}
