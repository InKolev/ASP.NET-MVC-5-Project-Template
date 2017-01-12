namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IUsersService users;
        private readonly IWorkplaceService workplaces;

        public HomeController(IUsersService users, IWorkplaceService workplaces)
            : base()
        {
            this.users = users;
            this.workplaces = workplaces;
        }

        public ActionResult Index()
        {
            var mapper = this.Mapper.ConfigurationProvider;

            // My test
            var items = this.workplaces.GetMany();
            var itemsOptimized = this.workplaces.GetMany<WorkplaceViewModel>(x => x.Id < 20);

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
