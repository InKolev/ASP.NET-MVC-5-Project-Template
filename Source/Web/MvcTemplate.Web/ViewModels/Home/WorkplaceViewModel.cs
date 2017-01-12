namespace MvcTemplate.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class WorkplaceViewModel : IMapFrom<Workplace>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}