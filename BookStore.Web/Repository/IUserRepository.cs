using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Web.Models.Admin;

namespace BookStore.Web.Repository
{
    public interface IUserRepository
    {
        public Task<IList<User>> GetAll();

        public Task<User> Get(string id);

        public Task Update(User user);

        public Task Delete(string id);
    }
}