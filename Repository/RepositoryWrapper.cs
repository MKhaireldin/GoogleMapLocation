using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IUserLocationRepository _userLocation;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IUserLocationRepository UserLocationRepository
        {
            get
            {
                if(_userLocation == null)
                {
                    _userLocation = new UserLocationRepository(_repositoryContext);
                }
                return _userLocation; ;
            }
        }

        public string Save()
        {
            if (_repositoryContext.SaveChanges() > 0)
            {
                return "Added Sucessfully!";
            }
            else
            {
                return "Something went wrong!";
            }
        }
    }
}
