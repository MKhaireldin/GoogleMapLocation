using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class UserLocationRepository: RepositoryBase<UserLocation> , IUserLocationRepository
    {
        private IUserLocationRepository _userLocation;
        public UserLocationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {            
        }        
    }
}
