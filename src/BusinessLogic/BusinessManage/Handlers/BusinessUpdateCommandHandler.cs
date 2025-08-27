using MediatR;
using poroject_777.src.BusinessLogic.BusinessManage.Comands;
using poroject_777.src.BusinessLogic.BusinessSearch.Models;
using poroject_777.src.DataAccess;
using poroject_777.src.DataAccess.Repositories;

namespace poroject_777.src.BusinessLogic.BusinessManage.Handlers
{
    public class BusinessUpdateCommandHandler : IRequestHandler<BusinessUpdateCommand, bool>
    {
        private GenericRepository<Business> BusinessRepository;

        public BusinessUpdateCommandHandler(DataContext dataContext)
        {
            BusinessRepository = new GenericRepository<Business>(dataContext);
        }

        public async Task<bool> Handle(BusinessUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await BusinessRepository.Update(request.business, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating genre: {ex.Message}");
                return false;
            }
        }
    }
}
