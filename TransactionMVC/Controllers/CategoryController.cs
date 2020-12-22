using AutoMapper;
using BL.Models;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionMVC.App_Start;
using TransactionMVC.Models;

namespace TransactionMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController()
        {
            _categoryService = new CategoryService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WebAutoMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WebAutoMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        public ActionResult Index()
        {
            var blModels = _categoryService.GetCategories();
            var models = _mapper.Map<IEnumerable<CategoryModel>>(blModels);

            return View("/Views/Category/Index.cshtml", models);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel categoryModel)
        {
            categoryModel.CreatedDate = DateTime.Now;
            categoryModel.UpdatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CategoryBLModel>(categoryModel);
                _categoryService.Create(category);

                return Index();
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            _categoryService.DeleteById(id);

            return Index();
        }

        public ActionResult Edit(int id)
        {
            var model = _categoryService.GetById(id);
            var categoryModel = _mapper.Map<CategoryModel>(model);

            return View(categoryModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                category.UpdatedDate = DateTime.Now;
                var blCategory = _mapper.Map<CategoryBLModel>(category);
                _categoryService.Edit(blCategory);

                return Index();
            }

            return View(category);
        }

        public ActionResult GetTransactionList()
        {
            TransactionModel transaction = new TransactionModel();
            transaction.Title = "test";
            transaction.Value = 500;

            return PartialView("~/Views/Transaction/_TransactionData.cshtml", transaction);
        }
    }
}