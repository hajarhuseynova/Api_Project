
using ApiIntro.Core.Entities;
using ApiIntro.Core.Repositories;
using ApiIntro.Data.Context;

namespace ApiIntro.Data.Repositories.Implementations
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {

        private readonly ApiIntroDbContext _context;

        public CategoryRepository(ApiIntroDbContext context):base(context)
        {
            _context = context;
        }
    }
}
