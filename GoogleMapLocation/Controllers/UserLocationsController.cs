using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoogleMapLocation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLocationsController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserLocationsController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet(Name = "GetUserLocations")]
        public List<UserLocation> GetAllUserLocations()
        {
            var userLocations = _repositoryWrapper.UserLocationRepository.GetAll().ToList();
            return userLocations;
        }

        [HttpPost(Name = "CreateUserLocation")]
        public string CreateUserLocation(UserLocation userLocation)
        {
            _repositoryWrapper.UserLocationRepository.Create(userLocation);
            return _repositoryWrapper.Save();
        }
    }
}