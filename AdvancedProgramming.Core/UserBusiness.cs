using AdvancedProgramming.Data;
using AdvancedProgramming.Data.Repositories;
using System.Collections.Generic;

namespace AdvancedProgramming.Core
{

    public class UserBusiness
    {
        private readonly IRepositoryUser _repositoryUser;


        public int Count { get; set; }


        protected int Total { get; set; }

        public UserBusiness()
        {
            _repositoryUser = new RepositoryUser();
        }

        public bool SaveOrUpdate(UserDetail user)
        {
            if (user.Id <= 0)
                _repositoryUser.Add(user);
            else
                _repositoryUser.Update(user);

            return true;
        }

        public bool Delete(int id)
        {
            _repositoryUser.Delete(id);
            return true;
        }

        public IEnumerable<UserDetail> GetUsers(int id)
        {
            return id <= 0
                ? _repositoryUser.GetAll()
                : new List<UserDetail>() { _repositoryUser.GetById(id) };
        }
    }
}
