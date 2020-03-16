using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db;

    public ItemsController(ToDoListContext db)
    {
      _db = db;
    }

    [HttpGet("/items")]
    public ActionResult Index()
    {
      return View(_db.Items.ToList());
    }

    [HttpGet("/items/{id}")]
    public ActionResult Details(long id)
    {
      var item = _db.Items
        .Include(i => i.Categories)
        .ThenInclude(join => join.Category)
        .FirstOrDefault(i => i.ItemId == id);
      return View(item);
    }

    [HttpPost("/items/create")]
    public ActionResult Create(Item item, long categoryId)
    {
      _db.Items.Add(item);
      _db.SaveChanges(); // todo: figure out how to do this in one query
      if (categoryId != 0)
      {
        _db.CategoryItem.Add(new CategoryItem {CategoryId = categoryId, ItemId = item.ItemId});
      }

      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/items/create")]
    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View("Create");
    }

    [HttpGet("/items/edit")]
    public ActionResult Edit(long id)
    {
      var item = _db.Items.FirstOrDefault(items => items.ItemId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(item);
    }

    [HttpPost("/items/edit")]
    public ActionResult Edit(Item item, long categoryId)
    {
      if (categoryId != 0)
      {
        _db.CategoryItem.Add(new CategoryItem {CategoryId = categoryId, ItemId = item.ItemId});
      }

      _db.Entry(item).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/items/{id}/AddCategory")]
    public ActionResult AddCategory(long id)
    {
      var item = _db.Items.FirstOrDefault(items => items.ItemId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(item);
    }

    [HttpPost("/items/{id}/AddCategory")]
    public ActionResult AddCategory(Item item, long categoryId)
    {
      if (categoryId != 0)
      {
        _db.CategoryItem.Add(new CategoryItem {CategoryId = categoryId, ItemId = item.ItemId});
      }

      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/items/{id}/destroy")]
    public ActionResult Delete(long id)
    {
      var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    [HttpPost("/items/{id}/destroy")]
    [ActionName("Delete")]
    public ActionResult DeleteConfirmed(long id)
    {
      var thisItem = _db.Items
        .FirstOrDefault(item => item.ItemId == id);
      _db.Items.Remove(thisItem);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost("/items/DeleteCategory")]
    public ActionResult DeleteCategory(long joinId)
    {
      var join = _db.CategoryItem.FirstOrDefault(j => j.CategoryItemId == joinId);
      _db.CategoryItem.Remove(join);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}