using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XStech.Models;

namespace XStech.ViewComponents
{
    public class NewsCategoryViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public NewsCategoryViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(string category)
        {
            var posts = await GetPostsAsync(category);
            var teasers = RecentNewsViewComponent.GetTeasers(posts);

            if (category == "Videos")
            {
                return View("VideosCategory", (posts, teasers));
            }

            return View((posts, teasers));
        }

        private async Task<List<Post>> GetPostsAsync(string category)
        {
            return await _db.Posts
                .Where(p => p.Category == category)
                .Include(p => p.Author)
                .OrderByDescending(p => p.UploadDate)
                .ToListAsync();
        }


    }
}
