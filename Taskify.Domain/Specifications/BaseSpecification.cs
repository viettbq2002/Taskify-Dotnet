﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taskify.Domain.SeedWorks;

namespace Taskify.Domain.Specifications
{
    public class BaseSpecification<T>(Expression<Func<T, bool>> predicate) : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Predicate { get; } = predicate;

        public List<Expression<Func<T, object>>> Includes { get; } = [];
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
