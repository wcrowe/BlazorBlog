using BlazorBlog.Application.Articles.GetArticlesByCurrentUser;
using BlazorBlog.Application.Articles.TogglePublish;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Application.Articles
{
    public class ArticlesOverviewService : IArticleOverviewService
    {
        private readonly ISender _sender;

        public ArticlesOverviewService(ISender sender)
        {
            _sender = sender;
        }

        public async Task<List<ArticleResponse>?> GetArticlesByCurrentUserAsync()
        {
            var results = await _sender.Send(new GetArticlesByCurrentUserQuery());
            return results;
        }

        public async Task<ArticleResponse?> TogglePublishArticleAsync(int articlId)
        {
            var result = await _sender.Send(new TogglePublishArticleCommand { ArticleId = articlId });
            return result;
        }
    }
}
