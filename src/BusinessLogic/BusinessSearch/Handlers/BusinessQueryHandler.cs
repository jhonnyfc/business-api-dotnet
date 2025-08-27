using MediatR;
using poroject_777.src.BusinessLogic.BusinessSearch.Models;
using poroject_777.src.BusinessLogic.BusinessSearch.Queries;
using poroject_777.src.DataAccess;
using poroject_777.src.DataAccess.Repositories;

namespace poroject_777.src.BusinessLogic.BusinessSearch.Handlers
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
