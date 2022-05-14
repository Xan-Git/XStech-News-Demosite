using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XStech.Models;

namespace XStech.ViewComponents
{
    public class RecentNewsViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public RecentNewsViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await GetPostsAsync();
            var teasers = GetTeasers(posts);

            // Data sent as tuple: (List<Post>, List<string>)
            return View((posts, teasers));
        }

        private async Task<List<Post>> GetPostsAsync()
        {
            return await _db.Posts
                .Where(p => (p.Category != "Tips" && p.Category != "Reviews" && p.Category != "Videos"))
                .Include(p => p.Author)
                .OrderByDescending(p => p.UploadDate)
                .Take(10)
                .ToListAsync();
        }

        public static List<string> GetTeasers(List<Post> posts)
        {
            List<string> teasers = new();

            foreach (Post post in posts)
                teasers.Add("In lobortis pharetra mattis. Morbi nec nibh iaculis, bibendum augue a, ultrices nulla. Nunc velit ante, lacinia id tincidunt eget, faucibus nec nisl. In mauris purus, bibendum et gravida dignissim, venenatis.");

            return teasers;

        }
    }
}
