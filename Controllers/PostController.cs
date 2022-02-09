namespace post_chat_api.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
       public PostController(IPostService postService, IMapper mapper)
       {
           _postService = postService;
           _mapper = mapper;
       }

        [AllowAnonymous]
        [HttpGet("GetAll")]
       public async Task<ActionResult<ServiceResponse<List<GetPostDto>>>> Get()
       {
           return Ok(await _postService.GetAllPosts()); //sends status code 200 (OK) and post object
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<ServiceResponse<GetPostDto>>> GetSingle(int id)
        {
            return Ok(await  _postService.GetPostById(id)); //Default will return a null if no character with id is found
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetPostDto>>>> AddPost(Post newPost)
        {
            return Ok(await _postService.AddPost(_mapper.Map<AddPostDto>(newPost)));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetPostDto>>> UpdatePost(UpdatePostDto updatedPost)
        {
            var response = await _postService.UpdatePost(updatedPost);

            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetPostDto>>>> Delete(int id)
        {
            var response = await _postService.DeletePost(id);

            if (response.Data == null)
            {
                return Ok(null);
            }
            return NotFound(response);
        }
    }
}