using AutoMapper;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TransactionMVC.App_Start;
using TransactionMVC.Models;

namespace TransactionMVC.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public StatisticController()
        {
            _categoryService = new CategoryService();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WebAutoMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }
        
        public StatisticController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WebAutoMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult AutoCompleteSuggestion(string query)
        {
            var categories = _categoryService.GetCategories().Where(x => x.Title.Contains(query)).ToList();
            var filteredSuggestions = _mapper.Map<IEnumerable<AutoCompleteModel>>(categories);
            var result = new JsonResult();
            result.Data = new { suggestions = filteredSuggestions };

            return Json(new { suggestions = filteredSuggestions }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNumberOfTransactionsByDay(int categoryId)
        {
            int[] reportData = new int[] {
                _categoryService.GetById(categoryId).Transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Monday).Count(),
                _categoryService.GetById(categoryId).Transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Tuesday).Count(),
                _categoryService.GetById(categoryId).Transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Wednesday).Count(),
                _categoryService.GetById(categoryId).Transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Thursday).Count(),
                _categoryService.GetById(categoryId).Transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Friday).Count(),
                _categoryService.GetById(categoryId).Transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Saturday).Count(),
                _categoryService.GetById(categoryId).Transactions.Where(x => x.CreatedDate.DayOfWeek == DayOfWeek.Sunday).Count()};

            var result = Json(new { result = reportData }, JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}