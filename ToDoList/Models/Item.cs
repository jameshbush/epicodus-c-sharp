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
    public long CategoryId { get; set; }
    public ICollection<CategoryItem> Categories { get; }
  }
}