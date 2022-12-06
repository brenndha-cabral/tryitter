using Microsoft.EntityFrameworkCore;
using tryitter.Database;
using tryitter.DTO;
using tryitter.Interfaces;
using tryitter.Models;

namespace tryitter.Repository
{
    public class PostRepository : IPostRepository
    {
        protected readonly AplicationContext _context;

        public PostRepository(AplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostDTO>> GetPosts()
        {
            var posts = await _context.Posts
                .Select(s => new PostDTO
                {
                    PostId = s.PostId,
                    Content = s.Content,
                    Release = s.Release,
                    StudentId = s.StudentId,
                }).ToListAsync();

            return posts;
        }

        public async Task<PostDTO> GetPostById(int id)
        {
            var post = await _context.Posts.Where(s => s.PostId == id)
                .Select(s => new PostDTO
                {
                    PostId = s.PostId,
                    Content = s.Content,
                    Release = s.Release,
                    StudentId = s.StudentId,
                }).FirstOrDefaultAsync();

            return post;
        }

        public async Task<PostDTO> CreatePost(Post post)
        {
            await _context.Posts.AddAsync(post);
            _context.SaveChanges();

            return new PostDTO
            {
                PostId = post.PostId
            };
        }

        public async Task<PostDTO> UpdatePost(Post newPost, int posttId)
        {
            var post = await _context.Posts.FindAsync(posttId);

            post.Content = newPost.Content;
            post.Release = newPost.Release;

            _context.SaveChanges();

            return new PostDTO
            {
                PostId = newPost.PostId
            };
        }

        public void DeletePost(int posttId)
        {
            var post = _context.Posts.Find(posttId);

            if (post is null)
            {
                throw new Exception("Post not found");
            }

            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
