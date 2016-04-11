using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Travels;

namespace ViaYou.Data.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public void Add(Category category)
        {
            Context.Categories.Add(category);
            SaveChanges();
        }

        public IQueryable<Category> GetAll()
        {
            return Context.Categories;
        }

        public Category GetById(int id)
        {
            return Context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(Category category)
        {
            Context.Categories.Remove(category);
        }

        public void Update(int id, string name)
        {
            var category = Context.Categories.FirstOrDefault(c => c.Id == id);
            category.Name = name;
        }
    }
}
