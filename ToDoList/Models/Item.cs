using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    private static readonly List<Item> _instances = new List<Item>();

    public Item(string description)
    {
      Description = description;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public string Description { get; set; }
    public int Id { get; }

    public static List<Item> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Item Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}