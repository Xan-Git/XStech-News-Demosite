using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XStech.Models;

namespace XStech.ViewComponents
{
    public class FeaturedNewsViewComponent: ViewComponent
    {
        private readonly AppDbContext _db;
        public FeaturedNewsViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var featuredNews = await GetPostsAsync();
            return View(featuredNews);
        }

        private async Task<List<Post>> GetPostsAsync()
        {
             return await _db.Posts
                .Where(p => (p.Category != "Tips" && p.Category != "Reviews" && p.Category != "Videos"))
                .Include(p => p.Author)
                .OrderByDescending(p => p.Views)
                .Take(3)
                .ToListAsync();

            
                   
        }
    }
}
