namespace MvcTemplate.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        public HomeController(IUsersService users)
            : base()
        {
            this.Users = users;
        }

        public IUsersService Users { get; set; }

        public ActionResult Index()
        {
            var mapper = this.Mapper.ConfigurationProvider;

            var userId = this.User.Identity.IsAuthenticated ? this.User.Identity.GetUserId() : null;
            var user = this.Users.All().FirstOrDefault(x => x.Id == userId);
            var model = this.Mapper.Map<UserViewModel>(user);

            return this.View(model);
        }

        public JsonResult GetJson()
        {
            return this.Json(new { Name = "Nameeee", Age = "1241241" }, JsonRequestBehavior.AllowGet);
        }
    }
}
