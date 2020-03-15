using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public Item()
    {
      Categories = new HashSet<CategoryItem>();
    }

    public long ItemId { get; set; }
    public string Description { get; set; }
    public ICollection<CategoryItem> Categories { get; } // this "collection navigation property" doesn't need to be virtual/lazy
  }
}