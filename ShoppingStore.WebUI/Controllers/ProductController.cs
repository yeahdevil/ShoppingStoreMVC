using ShoppingStore.Domain.Abstract;
using ShoppingStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository= repo;
        }
        // GET: Product
        public ActionResult List(string category , int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel() {
            Products = repository.Products
                .Where(p=>category==null || p.Category==category)
                .OrderBy(p=>p.ProductId)
                .Skip((page-1)*PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemesPerPage = PageSize,
                TotalItems = category==null?
                repository.Products.Count():repository.Products.Where(p=>p.Category==category).Count()
            },
            CurrentCategory= category
            };

            return View(model);
        }
    }
}