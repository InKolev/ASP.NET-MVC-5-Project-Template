namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using MvcTemplate.Data.Models;

    public interface IUsersService
    {
        IQueryable<ApplicationUser> All();

        ApplicationUser GetById(string id);
    }
}
