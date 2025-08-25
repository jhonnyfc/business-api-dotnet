using MediatR;
using poroject_777.BusinessLogic.BusinessSearch.Models;
using poroject_777.BusinessLogic.BusinessSearch.Queries;
using poroject_777.DataAccess;
using poroject_777.DataAccess.Repositories;

namespace poroject_777.BusinessLogic.BusinessSearch.Handlers
{
    public class BusinessQueryHandler : IRequestHandler<BusinessQuery, IEnumerable<Business>>
    {
        private GenericRepository<Business> BusinessRepository;

        public BusinessQueryHandler(DataContext datacContext)
        {
            BusinessRepository = new GenericRepository<Business>(datacContext);
        }

        public Task<IEnumerable<Business>> Handle(BusinessQuery request, CancellationToken cancellationToken)
        {
            var data = BusinessRepository.GetAllAsync(cancellationToken);
            return data;
        }
    }
}
