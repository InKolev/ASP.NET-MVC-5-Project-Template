namespace MvcTemplate.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IUsersService users;

        public HomeController(IUsersService users)
            : base()
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            var mapper = this.Mapper.ConfigurationProvider;

            var userId = this.User.Identity.IsAuthenticated ? this.User.Identity.GetUserId() : null;
            var user = this.users.All().FirstOrDefault(x => x.Id == userId);
            var model = this.Mapper.Map<UserViewModel>(user);

            return this.View(model);
        }

        public JsonResult GetJson()
        {
            return this.Json(new { Message = "That message was sent via AJAX. You must be very happy!" }, JsonRequestBehavior.AllowGet);
        }
    }
}
