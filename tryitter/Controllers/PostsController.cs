using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();

            if (!(posts?.Any() == true))
            {
                return NotFound("Posts not fount");
            }

            return Ok(posts);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var getClaim = identity.FindFirst("Id").Value;

            if (Convert.ToInt32(getClaim) != post.StudentId)
            {
                return Unauthorized("Student logged in does not match the StudentId entered in the post.");
            }

            await _postRepository.CreatePost(post);

            return Created("", "Post registered successfully!");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost([FromBody] Post post, int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var getClaim = identity.FindFirst("Id").Value;

            if (Convert.ToInt32(getClaim) != id)
            {
                return Unauthorized("Student logged in does not match the one sought for updating. Unable to updated.");
            }

            var postById = await _postRepository.GetPostById(id);

            if (postById is null)
            {
                return NotFound("Post not fount");
            }

            var updatePost = _postRepository.UpdatePost(post, id);

            return Ok("Post successfully updated!");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var getClaim = identity.FindFirst("Id").Value;

            if (Convert.ToInt32(getClaim) != id)
            {
                return Unauthorized("Logged in student does not match the student who made the post. Unable to remove.");
            }

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