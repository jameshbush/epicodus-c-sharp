using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db;

    public ItemsController(ToDoListContext db) => _db = db;

    [HttpGet("/items")]
    public ActionResult Index()
    {
      return View(_db.Items
        .Include(items => items.Category)
        .ToList());
    }

    [HttpGet("/items/{id}")]
    public ActionResult Details(long id)
    {
      return View(_db.Items.FirstOrDefault(item => item.ItemId == id));
    }

    [HttpPost("/items/create")]
    public ActionResult Create(Item item)
    {
      _db.Items.Add(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/items/create")]
    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(
        _db.Categories,
        "CategoryId",
        "Name"
      );
      return View("Create");
    }

    [HttpGet("/items/edit")]
    public ActionResult Edit(long id)
    {
      var item = _db.Items.FirstOrDefault(items => items.ItemId == id);
      ViewBag.CategoryId = new SelectList(
        _db.Categories,
        "CategoryId",
        "Name",
        $"{item.CategoryId}"
      );
      return View(item);
    }

    [HttpPost("/items/edit")]
    public ActionResult Edit(Item item)
    {
      _db.Entry(item).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/items/{id}/destroy")]
    public ActionResult Delete(long id)
    {
      var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    [HttpPost("/items/{id}/destroy"), ActionName("Delete")]
    public ActionResult DeleteConfirmed(long id)
    {
      var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      _db.Items.Remove(thisItem);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}