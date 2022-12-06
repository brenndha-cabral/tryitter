using tryitter.DTO;
using tryitter.Models;

namespace tryitter.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostDTO>> GetPosts();
        Task<PostDTO> GetPostById(int id);
        Task<PostDTO> CreatePost(Post post);
        Task<PostDTO> UpdatePost(Post post, int postId);
        void DeletePost(int id);
    }
}
