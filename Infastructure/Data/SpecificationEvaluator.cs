using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Data
{
    public class SpecificationEvaluator<TEnity> where TEnity : BaseEnity
    {
        public static IQueryable<TEnity> GetQuery(IQueryable<TEnity> inputQuery, ISpecification<TEnity> spec)
        {
            var query = inputQuery;
            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDesc != null)
            {
                query = query.OrderBy(spec.OrderByDesc);
            }

            if(spec.isPagingEnabled == true)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);

            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;

        }
    }
}
