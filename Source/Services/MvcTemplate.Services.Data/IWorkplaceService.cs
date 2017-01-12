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

    public interface IWorkplaceService
    {
        IEnumerable<Workplace> GetMany<T>();
        IEnumerable<Workplace> GetMany<T>(Expression<);
    }
}
