namespace MvcTemplate.Web.Controllers
{
    using System.Collections.Generic;
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

            // Projections made on the Web server (reduced performance, increased network traffic)
            var items = this.workplaces.GetMany();
            var itemsProjected = this.Mapper.Map<IEnumerable<WorkplaceViewModel>>(items);

            // Projections made on the Database server (increased performance, reduced network traffic)
            var itemsOptimized = this.workplaces.GetMany<WorkplaceViewModel>();

            var userId = this.User.Identity.IsAuthenticated ? this.User.Identity.GetUserId() : null;
            var user = this.users.All().FirstOrDefault(x => x.Id == userId);
            var model = this.Mapper.Map<UserViewModel>(user);

            return this.View(model);
        }

        public ActionResult FirstPage()
        {
            return this.View();
        }

        public ActionResult SecondPage()
        {
            return this.View();
        }

        public JsonResult GetJson()
        {
            return this.Json(new { Message = "That message was sent via AJAX. You must be very happy!" }, JsonRequestBehavior.AllowGet);
        }
    }
}
