using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XStech.Models;

namespace XStech.ViewComponents
{
    public class NavViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public NavViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navPosts = await GetPostsAsync("Microsoft", "Apple", "Android", "Hardware", "Startups");
            return View(navPosts);
        }

        // Pass in any # of categories as parameters (5 expected) =>
        // Get 4 most recent posts of that category.
        // Ask for categories in order you want displayed
        // If not asking for 5 categories, refactor componentView to display as desired
        private async Task<List<List<Post>>> GetPostsAsync(params string[] category)
        {
            List<List<Post>> listsByCategory = new();

            for (int i = 0; i < category.Length; i++)
            {
                listsByCategory.Add(await _db.Posts
                                    .Where(p => p.Category == category[i])
                                    .OrderByDescending(p => p.UploadDate)
                                    .Take(4)
                                    .ToListAsync());
            }

            return listsByCategory;
        }
    }
}
