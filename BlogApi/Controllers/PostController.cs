using BlogApi.Data;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace BlogApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var posts = _context.Posts.Select(x => new PostDto
            {
                Content = x.Content,
                Title = x.Title,
                CreatedAt = x.CreatedAt,   
            });
            return Ok(posts);
        }


        [HttpGet("admin")]
        public IActionResult GetAllPostsAdmin()
        {
            return Ok(_context.Posts.ToList());
        }

        [HttpGet("bytitle")]
        public IActionResult GetByTitle(string title)
        {
            var post = _context.Posts.Where(x => x.Title
            .Contains(title))
            .Select(x => new PostDto
            {
                Content = x.Content,
                Title = x.Title,
                CreatedAt = x.CreatedAt,
            });
            return Ok(post);
        }
        [HttpGet("sorted")]
        public IActionResult GetSortedByDate()
        {
            var post = _context.Posts
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new PostDto
                {
                    Content = x.Content,
                    Title = x.Title,
                    CreatedAt = x.CreatedAt
                });
            return Ok(post);
        }


        [HttpPost]
        public IActionResult CreatPost(CreatePostDto dto)
        {
            if (string.IsNullOrEmpty(dto.Title))
                return BadRequest("Enter Title");

            if (string.IsNullOrEmpty(dto.Content))
                return BadRequest("Enter Content");

            var post = new Post
            {
                Title = dto.Title,
                Content = dto.Content,
                CreatedAt = DateTime.Now,
            };
            _context.Posts.Add(post);
            _context.SaveChanges();
            return Ok(post);
        }

        [HttpPut("{id}")]
        public IActionResult EditPost(CreatePostDto Newdto, int id)
        {
                var post = _context.Posts.FirstOrDefault(x => x.Id == id);
                if (post == null)
                    return BadRequest("Post dosen't exist");
                if (string.IsNullOrEmpty(Newdto.Title))
                    return BadRequest("Enter Title");

                if (string.IsNullOrEmpty(Newdto.Content))
                    return BadRequest("Enter Content");

                post.Title = Newdto.Title;
                post.Content = Newdto.Content;
                _context.SaveChanges();
                return Ok(post);
            
        }

        [HttpDelete("{id}")] 
        public IActionResult DeletePost(int id)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Id == id);

            if (post == null)
                return BadRequest();
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
