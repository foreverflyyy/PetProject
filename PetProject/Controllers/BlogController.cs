using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Columns;

namespace PetProject.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        /// <summary>
        /// Метод для получения постов
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        [Route("page")]
        [HttpGet]
        public async Task<Page<Post>> GetPosts(int pageIndex, string tag)
        {
            return await _blogRepository.GetPosts(pageIndex, 10, tag);
        }
    }
}