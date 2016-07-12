namespace MvcTemplate.Web.ViewModels.Home
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
