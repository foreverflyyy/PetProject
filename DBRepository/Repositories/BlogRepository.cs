using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Models.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository
{
    /// <summary>
    /// Блог репозиторий для работы с постами
    /// </summary>
    public class BlogRepository : BaseRepository, IBlogRepository
    {
        public BlogRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

        /// <summary>
        /// Получаем нужные посты
        /// </summary>
        /// <param name="index">  </param>
        /// <param name="pageSize">  </param>
        /// <param name="tag"> Нужные теги </param>
        /// <returns></returns>
        public async Task<Page<Post>> GetPosts(int index, int pageSize, string tag = null)
        {
            var result = new Page<Post>() { CurrentPage = index, PageSize = pageSize };

            // Создаём БД и производим в ней операции
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Posts.AsQueryable();
                if (!string.IsNullOrWhiteSpace(tag))
                {
                    query = query.Where(p => p.Tags.Any(t => t.TagName == tag));
                }

                result.TotalPages = await query.CountAsync();

                // Запрос для получения нужной нам страницы постов вместе с тегами
                query = query.Include(p => p.Tags).Include(p => p.Comments).OrderByDescending(p => p.CreatedData)
                    .Skip(index * pageSize).Take(pageSize);

                // Само обращение к базе
                result.Records = await query.ToListAsync();
            }
            
            return result;
        }
    }
}
