
using ApiIntro.Core.Entities;
using ApiIntro.Core.Repositories;
using ApiIntro.Data.Context;

namespace ApiIntro.Data.Repositories.Implementations
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {

        private readonly ApiIntroDbContext _context;

        public ProductRepository(ApiIntroDbContext context):base(context)
        {
            _context = context;
        }
    }
}
