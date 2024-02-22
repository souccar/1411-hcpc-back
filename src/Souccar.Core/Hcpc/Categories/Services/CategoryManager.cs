using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Categories.Services
{
    public class CategoryManager : SouccarDomainService<Category, int>, ICategoryManager
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryManager(IRepository<Category> categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetWithDetailsAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category != null)
            {
                await _categoryRepository.EnsurePropertyLoadedAsync(category, w => w.ParentCategory);
            }

            return category;
        }


    }
}
