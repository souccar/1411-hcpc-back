using Abp.Domain.Entities;
using Abp.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Souccar.Core.Filter
{
    internal class NullFilterBuilder<TEntity, TPrimaryKey> : IFilterBuilder<TEntity, TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
    {
        public static NullFilterBuilder<TEntity, TPrimaryKey> Instance { get; } = new NullFilterBuilder<TEntity, TPrimaryKey>();
        
        IList<FilterInput> Initial(string filtering)
        {
            var filters = new List<FilterInput>();
            var inputs = filtering.Split(",");
            if (inputs.Any())
            {
                foreach(var input in inputs)
                {
                    var array = input.Split(":");
                    if (array.Any() && array.Length >= 3)
                    {
                        filters.Add(new FilterInput(array));
                    }
                }
            }
            return filters;
        }

        public IQueryable<TEntity> Filter(IQueryable<TEntity> queryable, string filtering)
        {
            var filters = Initial(filtering);
            if (filters.Any())
            {
                // Get all filter values as array (needed by the Where method of Dynamic Linq)
                var values = filters.Select(f => f.Value).ToArray();

                // Create a predicate expression e.g. Field1 = @0 And Field2 > @1
                string predicate = ToExpression(filters);

                // Use the Where method of Dynamic Linq to filter the data
                queryable = queryable.Where(predicate, values);
            }

            return queryable;
        }

        string ToExpression(IList<FilterInput> filters)
        {
            string predicate = "";
            if (filters != null && filters.Any())
            {
                for(var i = 0; i < filters.Count; i++)
                {
                    string comparison = operators[filters[i].Operator];

                    if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
                    {
                        predicate += String.Format("{0}.{1}(@{2}) {3} ", filters[i].Field, comparison, i, filters[i].Logic);
                    }

                    //else if (comparison =="In" || comparison =="NotIn")
                    //{
                    //    predicate +=
                    //}
                    else
                    {
                        predicate += String.Format("{0} {1} @{2} {3} ", filters[i].Field, comparison, i, filters[i].Logic);
                    }
                }
            }

            return predicate;
        }
        private readonly IDictionary<string, string> operators = new Dictionary<string, string>
        {
            {"eq", "="},
            {"neq", "!="},
            {"lt", "<"},
            {"lte", "<="},
            {"gt", ">"},
            {"gte", ">="},
            {"sw", "StartsWith"},
            {"ew", "EndsWith"},
            {"co", "Contains"},
            {"in", "In"},
            {"nin", "NotIn"},
        };
    }
}
