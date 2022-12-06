using Microsoft.AspNetCore.Mvc;
using tryitter.Interfaces;
using tryitter.Models;

namespace tryitter.Controllers
{
    [ApiController]
    [Route("posts")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();

            //Assim consigo ver se esse array anulável está nulo ou vazio, se fosse para verificar se estivesse apenas vazio, seria !posts.Any()
            if (!(posts?.Any() == true))
            {
                return NotFound("Posts not fount");
            }

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var student = await _postRepository.GetPostById(id);

            if (student is null)
            {
                return NotFound("Post not fount");
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            await _postRepository.CreatePost(post);

            return Created("", "Post registered successfully!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost([FromBody] Post post, int id)
        {
            var postById = await _postRepository.GetPostById(id);

            if (postById is null)
            {
                return NotFound("Post not fount");
            }

            var updatePost = _postRepository.UpdatePost(post, id);

            return Ok("Post successfully updated!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var postById = await _postRepository.GetPostById(id);

            if (postById is null)
            {
                return NotFound("Post not fount");
            }

            _postRepository.DeletePost(id);

            return NoContent();
        }
    }
}