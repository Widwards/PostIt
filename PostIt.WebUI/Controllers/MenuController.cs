using PostIt.Domain.Abstract;
using PostIt.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostIt.WebUI.Controllers
{
    public class MenuController : Controller
    {
        private INoteRepository repository;
        //
        // GET: /Navigation/

        public MenuController(INoteRepository paramRepo)
        {
            repository = paramRepo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category; 
            
            IEnumerable<string> categories = repository.Notes
                                                       .Select(x => x.Category)
                                                       .Distinct()
                                                       .OrderBy(x => x);

            //TODO: Add category notes count IEnumerable<CategoriesInfo> [DONE]

            List<CategoriesInfo> categoriesInfos = categories.ToList().Select(item => new CategoriesInfo
                {
                    Category = item, Number = repository.Notes.Count(x => x.Category == item)
                }).ToList();


            return PartialView(categoriesInfos);

        }
    }
}
