using AutoMapper;
using BL.Models;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface ICategoryService
    {
        void Create(CategoryBLModel model);
        void DeleteById(int id);
        CategoryBLModel GetById(int id);
        void Edit(CategoryBLModel model);
        IEnumerable<CategoryBLModel> GetCategories();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<BLAutoMapperProfile>());

            _mapper = new Mapper(mapperConfig);
        }

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<BLAutoMapperProfile>());

            _mapper = new Mapper(mapperConfig);
        }

        public void Create(CategoryBLModel model)
        {
            var category = _mapper.Map<Category>(model);
            _categoryRepository.Create(category);
        }

        public void DeleteById(int id)
        {
            _categoryRepository.DeleteById(id);
        }

        public CategoryBLModel GetById(int id)
        {
            var category = _categoryRepository.GetById(id);

            return _mapper.Map<CategoryBLModel>(category);
        }

        public void Edit(CategoryBLModel model)
        {
            var category = _mapper.Map<Category>(model);
            _categoryRepository.Edit(category);
        }

        public IEnumerable<CategoryBLModel> GetCategories()
        {
            var categories = _categoryRepository.GetMyCategories();
            return _mapper.Map<IEnumerable<CategoryBLModel>>(categories);
        }
    }
}
