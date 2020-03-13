using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ToDoListContext _db;

    public CategoriesController(ToDoListContext db) => _db = db;

    [HttpGet("/categories")]
    public ActionResult Index()
    {
      return View(_db.Categories.ToList());
    }

    [HttpGet("/categories/create")]
    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost("/categories/create")]
    public ActionResult Create(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("categories/{id}")]
    public ActionResult Details(long id)
    {
      return View(_db.Categories.FirstOrDefault(category => category.CategoryId == id));
    }

    [HttpGet("categories/{id}/edit")]
    public ActionResult Edit(long id)
    {
      return View(_db.Categories.FirstOrDefault(category => category.CategoryId == id));
    }

    [HttpPost("categories/{id}/edit")]
    public ActionResult Edit(Category category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/categories/{id}/delete")]
    public ActionResult Delete(long id)
    {
      return View(_db.Categories.FirstOrDefault(category => category.CategoryId == id));
    }

    [HttpPost("/categories/{id}/delete"), ActionName("Delete")]
    public ActionResult DeleteConfirmed(long id)
    {
      var category = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
      _db.Categories.Remove(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}