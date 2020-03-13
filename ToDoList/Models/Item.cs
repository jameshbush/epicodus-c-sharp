namespace ToDoList.Models
{
  public class Item
  {
    public long ItemId { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public virtual Category Category { get; set; }
  }
}