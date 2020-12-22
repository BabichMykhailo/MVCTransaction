using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ICategoryRepository
    {
        void Create(Category model);

        void DeleteById(int id);

        Category GetById(int id);
        void Edit(Category model);
        IEnumerable<Category> GetMyCategories();
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly TransactionMVCContext _ctx;

        public CategoryRepository()
        {
            _ctx = new TransactionMVCContext();
        }

        public void Create(Category model)
        {
            _ctx.Categories.Add(model);

            _ctx.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = _ctx.Categories.FirstOrDefault(x => x.Id == id);
            _ctx.Categories.Remove(entity);

            _ctx.SaveChanges();
        }

        public Category GetById(int id)
        {
            return _ctx.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(Category model)
        {
            _ctx.Entry(model).State = System.Data.Entity.EntityState.Modified;

            _ctx.SaveChanges();
        }

        public IEnumerable<Category> GetMyCategories()
        {
            return _ctx.Categories.ToList();
        }
    }
}
