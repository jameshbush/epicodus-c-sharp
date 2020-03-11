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
    public long Id { get; set; }

    public override bool Equals(object obj)
    {
      if (!(obj is Item)) return false;

      var newItem = (Item) obj;
      return (Description == newItem.Description && Id == newItem.Id);
    }

    public void Save()
    {
      var conn = Db.Connection();
      conn.Open();
      var cmd = conn.CreateCommand();
      cmd.CommandText = @"insert into items (description) values (@ItemDescription);";
      var description = new MySqlParameter
      {
        ParameterName = "@ItemDescription",
        Value = Description
      };
      cmd.Parameters.Add(description);
      cmd.ExecuteNonQuery();
      Id = cmd.LastInsertedId;
      conn.Close();
      conn?.Dispose();
    }

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
      var conn = Db.Connection();
      conn.Open();
      var cmd = conn.CreateCommand();
      cmd.CommandText = @"delete from items";
      cmd.ExecuteNonQuery();
      conn.Close();
      conn?.Dispose();
    }

    public static Item Find(long id)
    {
      var conn = Db.Connection();
      conn.Open();
      var cmd = conn.CreateCommand();
      cmd.CommandText = @"select * from `items` where id = @thisId;";
      var thisId = new MySqlParameter {ParameterName = "@thisId", Value = id};
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader();
      var itemId = 0;
      var itemDescription = "";
      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemDescription = rdr.GetString(1);
      }

      conn.Close();
      conn?.Dispose();

      return new Item {Description = itemDescription, Id = itemId};
    }
  }
}