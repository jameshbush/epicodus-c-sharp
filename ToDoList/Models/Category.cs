using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    private static readonly List<Category> _instances = new List<Category>();

    public Category()
    {
      Items = new HashSet<Item>();
    }

    public long CategoryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Item> Items { get; set; } // virtual allows lazy loading associations
  }
}