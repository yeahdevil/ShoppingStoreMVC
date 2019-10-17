using ShoppingStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repositry;
        public NavController(IProductRepository repo)
        {
            repositry = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repositry.Products
                                               .Select(x => x.Category)
                                               .Distinct()
                                               .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}