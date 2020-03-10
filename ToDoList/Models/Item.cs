using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Item
  {
    public Item(string description)
    {
      Description = description;
    }

    private Item()
    {
    }

    public string Description { get; set; }
    public int Id { get; set; }

    public static List<Item> GetAll()
    {
      var allItems = new List<Item>();
      var conn = Db.Connection();
      conn.Open();
      var cmd = conn.CreateCommand();
      cmd.CommandText = @"select * from items;";
      var rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        allItems.Add(new Item
        {
          Id = rdr.GetInt32(0),
          Description = rdr.GetString(1)
        });
      }

      conn.Close();

      conn?.Dispose();

      return allItems;
    }

    public static void ClearAll()
    {
    }

    public static Item Find(int searchId)
    {
      return new Item("placeholder item");
    }
  }
}