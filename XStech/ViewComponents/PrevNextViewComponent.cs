using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XStech.Models;

namespace XStech.ViewComponents
{
    public class PrevNextViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;

        public PrevNextViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(Post post)
        {
            (Post, Post) prevNextPosts = await GetPostsAsync(post);
            return View(prevNextPosts);
        }

        private async Task<(Post, Post)> GetPostsAsync(Post post)
        {
            List<Post> posts = await _db.Posts
                .OrderBy(p => p.UploadDate)
                .ToListAsync();

            int postIndex = posts.IndexOf(post);
            int prevIndex;
            int nextIndex;

            // If at beginning, wrap around to end
            if (postIndex == 0)
            {
                prevIndex = posts.Count - 1;
                nextIndex = postIndex + 1;
            }
            // If at end, wrap around to beginning
            else if (postIndex == posts.Count - 1)
            {
                nextIndex = 0;
                prevIndex = postIndex - 1;
            }
            else
            {
                prevIndex = postIndex - 1;
                nextIndex = postIndex + 1;
            }

            return (posts[prevIndex], posts[nextIndex]);
        }
    }
}
