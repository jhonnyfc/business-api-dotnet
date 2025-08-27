using MediatR;
using poroject_777.src.BusinessLogic.BusinessSearch.Models;
using poroject_777.src.BusinessLogic.BusinessSearch.Queries;
using poroject_777.src.DataAccess;
using poroject_777.src.DataAccess.Repositories;

namespace poroject_777.src.BusinessLogic.BusinessSearch.Handlers
{
    public class BusinessByQueryIdHandler : IRequestHandler<BusinessByIdQuery, Business>
    {
        private GenericRepository<Business> BusinessRepository;

        public BusinessByQueryIdHandler(DataContext datacContext)
        {
            BusinessRepository = new GenericRepository<Business>(datacContext);
        }

        public Task<Business> Handle(BusinessByIdQuery request, CancellationToken cancellationToken)
        {
            var data = BusinessRepository.GetByIdAsync(request.Id, cancellationToken);
            return data;
        }
    }
}
