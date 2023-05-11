using DbFirstNorthwind.Models;
using DbFirstNorthwind.Models.VM_s;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstNorthwind.Controllers
{
    public class CategoryController : Controller
    {

        private readonly NorthwindContext context;

        public CategoryController()
        {
            context = new NorthwindContext();

        }

        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM)
        {
            if (string.IsNullOrEmpty(categoryVM.CategoryName) || string.IsNullOrEmpty(categoryVM.Description))
            {
                ViewBag.Error = "Lütfen veri giriniz";
                return View();
            }
            Category category = new();
            category.CategoryName = categoryVM.CategoryName;
            category.Description = categoryVM.Description;
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Where(a => a.CategoryId == id).FirstOrDefault();
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                TempData["Bildiri"] = "Silme işlmei başarılı";
                return RedirectToAction("Index");
            }
            ViewBag.Bildiri = "Böyle bir kayıt yok";
            return View();
        }


        public IActionResult Edit(int id)
        {
            Category category = context.Categories.Where(a => a.CategoryId == id).FirstOrDefault();
            if (category != null)
            {
                CategoryUpdateVM categoryUpdateVM = new();
                categoryUpdateVM.CategoryName = category.CategoryName;
                categoryUpdateVM.Description = category.Description;
                categoryUpdateVM.CategoryId = category.CategoryId;
                return View(categoryUpdateVM);
            }
            ViewBag.Error = "Böyle bir kategori yok";
            return View();
        }

        [HttpPost]
        public IActionResult Edit(CategoryUpdateVM categoryUpdateVM)
        {
            if (string.IsNullOrEmpty(categoryUpdateVM.CategoryName) || string.IsNullOrEmpty(categoryUpdateVM.Description))
            {
                ViewBag.Error = "Lütfen veri giriniz";
                return View();
            }
            Category category = context.Categories.Where(a => categoryUpdateVM.CategoryId == a.CategoryId).FirstOrDefault();
            category.CategoryName = categoryUpdateVM.CategoryName;
            category.Description = categoryUpdateVM.Description;
            
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
