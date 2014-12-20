
using System.Collections.Generic;
using JustBlog.Core.Objects;

namespace JustBlog.Models
{
    /// <summary>
    /// View model used to wrap data for sidebar widgets.
    /// </summary>
    public class WidgetViewModel
    {
        public WidgetViewModel(IList<Category> categories, IList<Tag> tags, IList<Post> latestPosts)
        {
            this.Categories = categories;
            this.Tags = tags;
            this.LatestPosts = latestPosts;
        }

        public IList<Category> Categories
        { get; private set; }

        public IList<Tag> Tags
        { get; private set; }

        public IList<Post> LatestPosts
        { get; private set; }
    }
}