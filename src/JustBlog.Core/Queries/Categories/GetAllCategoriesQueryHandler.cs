﻿using System.Collections.Generic;
using System.Linq;
using JustBlog.Core.Infrastructure.Queries;
using JustBlog.Core.Objects;
using NHibernate;
using NHibernate.Linq;

namespace JustBlog.Core.Queries.Categories
{
    public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, IList<Category>>
    {
        private readonly ISession session;
        public GetAllCategoriesQueryHandler(ISession session)
        {
            this.session = session;
        }
        public IList<Category> Handle(GetAllCategoriesQuery query)
        {
            return session.Query<Category>().OrderBy(p => p.Name).ToList();
        }
    }
}
