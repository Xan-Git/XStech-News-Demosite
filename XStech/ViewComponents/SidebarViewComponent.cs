using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XStech.Models;

namespace XStech.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;

        public SidebarViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await GetPostsAsync();
            return View(posts);
        }

        private async Task<(List<Post>, List<Post>, List<Post>)> GetPostsAsync()
        {
            List<Post> trendPosts = await _db.Posts
                .Where(p => p.Category != "Videos" && p.Category != "Reviews")
                .OrderByDescending(p => p.Views)
                .Skip(3)
                .Take(3)
                .ToListAsync();

            List<Post> trendVids = await _db.Posts
                .Where(p => p.Category == "Videos")
                .OrderByDescending(p => p.Views)
                .Take(3)
                .ToListAsync();
            List<Post> recentReviews = await _db.Posts
                .Where(p => p.Category == "Reviews")
                .OrderByDescending(p => p.UploadDate)
                .Take(3)
                .ToListAsync();

            return (trendPosts, trendVids, recentReviews);
        }
    }
}
