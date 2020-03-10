using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Db
  {
    public static MySqlConnection Connection()
    {
      var conn = new MySqlConnection(DbConfiguration.ConnectionString);
      return conn;
    }
  }
}