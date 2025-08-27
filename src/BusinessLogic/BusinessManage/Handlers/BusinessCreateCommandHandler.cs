using MediatR;
using poroject_777.src.BusinessLogic.BusinessManage.Comands;
using poroject_777.src.BusinessLogic.BusinessSearch.Models;
using poroject_777.src.DataAccess;
using poroject_777.src.DataAccess.Repositories;

namespace poroject_777.src.BusinessLogic.BusinessManage.Handlers
{
    public class BusinessCreateCommandHandler : IRequestHandler<BusinessCreateCommand, bool>
    {
        private GenericRepository<Business> BusinessRepository;

        public BusinessCreateCommandHandler(DataContext dataContext)
        {
            BusinessRepository = new GenericRepository<Business>(dataContext);
        }

        public async Task<bool> Handle(BusinessCreateCommand request, CancellationToken cancellationToken)
        {
            var newBusiness = new Business
            {
                BusinessNikname = request.businessDTO.BusinessNikname,
                Telf = request.businessDTO.Telf,
                JoiningDate = request.businessDTO.JoiningDate,
                LeavingDate = request.businessDTO.LeavingDate,
                Description = request.businessDTO.Description,
                InstaLink = request.businessDTO.InstaLink,
                FacebookLink = request.businessDTO.FacebookLink,
                LinkedInLink = request.businessDTO.LinkedInLink,
                Email = request.businessDTO.Email,
                Adress = request.businessDTO.Adress,
                BusinessSector = request.businessDTO.BusinessSector,
            };
            try
            {
                await BusinessRepository.AddAsync(newBusiness, cancellationToken);
                return true;
            } catch (Exception ex) {
                Console.WriteLine($"Error saving genre: {ex.Message}");
                return false;
            }
        }
    }
}
