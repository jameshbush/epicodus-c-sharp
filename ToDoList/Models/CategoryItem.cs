namespace ToDoList.Models
{
  public class CategoryItem
  {
    public long CategoryItemId { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public long ItemId { get; set; }
    public Item Item { get; set; }
  }
}