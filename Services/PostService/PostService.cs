namespace scat_chat_api.Services.PostService
{
	public class PostService : IPostService
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public PostService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_context = context;
			_mapper = mapper;
		}

		private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

		public async Task<ServiceResponse<List<GetPostDto>>> AddPost(AddPostDto newPost)
		{
			var serviceResponse = new ServiceResponse<List<GetPostDto>>();
			Post post = _mapper.Map<Post>(newPost);
			post.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
			post.TimeCreated = DateTime.Now;
			_context.Posts.Add(post);
			await _context.SaveChangesAsync(); //will update Id with this call to database
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetPostDto>>> DeletePost(int id)
		{
			var serviceResponse = new ServiceResponse<List<GetPostDto>>();

			try
			{
				Post post = await _context.Posts.FirstOrDefaultAsync(s => s.Id == id && s.User.Id == GetUserId());
				if (post != null)
				{
					_context.Posts.Remove(post);
					await _context.SaveChangesAsync();
					serviceResponse.Data = null;
				}
				else
				{
					serviceResponse.Success = false;
					serviceResponse.Message = "Post not found.";
				}
			}
			catch (Exception e)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "No document found with that id.";
				serviceResponse.Data = _context.Posts.Select(c => _mapper.Map<GetPostDto>(c)).ToList();
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetPostDto>>> GetAllPosts()
		{
			var serviceResponse = new ServiceResponse<List<GetPostDto>>();
			var dbPosts = await _context.Posts.ToListAsync();
			serviceResponse.Data = dbPosts.Select(s => _mapper.Map<GetPostDto>(s)).ToList();
			return serviceResponse;
		}

		public async Task<ServiceResponse<GetPostDto>> GetPostById(int id)
		{
			var serviceResponse = new ServiceResponse<GetPostDto>();
			var dbPost = await _context.Posts.FirstOrDefaultAsync(post => post.Id == id);
			serviceResponse.Data = _mapper.Map<GetPostDto>(dbPost);
			return serviceResponse;
		}

		public async Task<ServiceResponse<GetPostDto>> UpdatePost(UpdatePostDto updatedPost)
		{
			var serviceResponse = new ServiceResponse<GetPostDto>();

			try
			{
				Post post = await _context.Posts
					.Include(s => s.User)
					.FirstOrDefaultAsync(s => s.Id == updatedPost.Id);
				if (post != null && post.User.Id == GetUserId())
				{
					post.Text = updatedPost.Text;
					post.Author = updatedPost.Author;
					post.Color = updatedPost.Color;

					await _context.SaveChangesAsync();

					serviceResponse.Data = _mapper.Map<GetPostDto>(post);
				}
				else 
				{
					serviceResponse.Success = false;
					serviceResponse.Message = "Post not found.";
				}
			}
			catch (Exception e)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = e.Message;
			}
			return serviceResponse;
		}
	}
}