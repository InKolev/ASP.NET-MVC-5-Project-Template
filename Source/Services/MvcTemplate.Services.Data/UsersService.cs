namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class UsersService : IUsersService
    {
        public UsersService(IUsersRepository<ApplicationUser> users)
        {
            this.Users = users;
        }

        public IUsersRepository<ApplicationUser> Users { get; set; }

        public IQueryable<ApplicationUser> All()
        {
            return this.Users.All();
        }

        public ApplicationUser GetById(string id)
        {
            return this.Users.GetById(id);
        }
    }
}
