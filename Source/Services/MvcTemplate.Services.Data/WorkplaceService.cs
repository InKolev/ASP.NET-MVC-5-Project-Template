namespace MvcTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class WorkplaceService : IWorkplaceService
    {
        private IDbRepository<Workplace> workplaces;

        public WorkplaceService(IDbRepository<Workplace> workplaces)
        {
            this.workplaces = workplaces;
        }

        public IEnumerable<Workplace> GetMany()
        {
            return this.workplaces.All().ToList();
        }

        public IEnumerable<Workplace> GetMany(Expression<Func<Workplace, bool>> whereFilter)
        {
            return this.workplaces.All().Where(whereFilter);
        }

        public IEnumerable<TOut> GetMany<TOut>(Expression<Func<Workplace, bool>> whereFilter)
        {
            return this.workplaces.All().Where(whereFilter).ProjectTo<TOut>().ToList();
        }
    }
}
