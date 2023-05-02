using System.Data.SqlClient;
using System.Drawing;
using System.Reflection.PortableExecutable;

namespace AppFruitsAndVegetables;
public static class ShowFunctions
{
    // Task 3
    public static void ShowAllInfo(SqlConnection conn)
    {
        using SqlCommand command = new("select * from VegetablesAndFruitsTable", conn);
        SqlDataReader reader = command.ExecuteReader();
        //foreach (var item in reader.GetColumnSchema())
        //{
        //    Console.Write(item.ColumnName + '\t');
        //}
        //Console.WriteLine();
        while (reader.Read())
        {
            Console.WriteLine($"{reader[0]}, {reader[1]},{reader[2]},{reader[3]},{reader[4]}");
        }
    }
    public static void ShowAllNames(SqlConnection conn)
    {
        using SqlCommand command = new("select * from VegetablesAndFruitsTable", conn);
        SqlDataReader reader = command.ExecuteReader(); 
        while (reader.Read())
        {
            Console.WriteLine($"{reader[1]} ");
        }
    }
    public static void ShowAllColors(SqlConnection conn)
    {
        using SqlCommand command = new("select * from VegetablesAndFruitsTable", conn);
        SqlDataReader reader = command.ExecuteReader(); 
        while (reader.Read())
        {
            Console.WriteLine($"{reader[3]} ");
        }
    }
    public static void ShowMaxColoricity(SqlConnection conn)
    {
        using SqlCommand command = new("select MAX(Coloricity) from VegetablesAndFruitsTable", conn);
        int max = Convert.ToInt32(command.ExecuteScalar());
        Console.WriteLine($"Max coloricity is {max}");
    }
    public static void ShowMinColoricity(SqlConnection conn)
    {
        using SqlCommand command = new("select MIN(Coloricity) from VegetablesAndFruitsTable", conn);
        int min = Convert.ToInt32(command.ExecuteScalar());
        Console.WriteLine($"Min coloricity is {min}");
    }
    public static void ShowAverageColoricity(SqlConnection conn)
    {
        using SqlCommand command = new("select AVG(Coloricity) from VegetablesAndFruitsTable", conn);
        int avg = Convert.ToInt32(command.ExecuteScalar());
        Console.WriteLine($"AVG coloricity is {avg}");
    }
    public static void CloseConnection(SqlConnection conn)
    {
        conn.Close();
        if (conn.State == System.Data.ConnectionState.Closed) Console.WriteLine("Lucky disconnection!)");
        else Console.WriteLine("Unlucky disconnection!(");
    }
    // Task 4
    public static void ShowCountOfVegetables(SqlConnection conn)
    {
        using SqlCommand command = new("SELECT * FROM VegetablesAndFruitsTable Where[Type] = N'Vegetable'", conn);
        SqlDataReader reader = command.ExecuteReader();
        int countOfVegetables = 0;
        while (reader.Read())
        {
            countOfVegetables++;
        }
        Console.WriteLine($"Count of vegetables is {countOfVegetables}");
    }
    public static void ShowCountOfFruits(SqlConnection conn)
    {
        using SqlCommand command = new("SELECT * FROM VegetablesAndFruitsTable Where[Type] = N'Fruit'", conn);
        SqlDataReader reader = command.ExecuteReader();
        int countOfFruits = 0;
        while (reader.Read())
        {
            countOfFruits++;
        }
        Console.WriteLine($"Count of fruits is {countOfFruits}");
    }
    public static void ShowCountOfVegetablesAndFruitsByColor(SqlConnection conn)
    {
        Console.WriteLine("Enter color -> ");
        string color = Console.ReadLine();
        using SqlCommand command = new($"SELECT * FROM VegetablesAndFruitsTable Where[Color] = N'{color}'", conn);
        SqlDataReader reader = command.ExecuteReader();
        int countOfVegetablesAndFruits = 0;
        while (reader.Read())
        {
            countOfVegetablesAndFruits++;
        }
        Console.WriteLine($"Count of vegetables and fruits with {color} is {countOfVegetablesAndFruits}");
    }
    public static void ShowCountOfVegetablesAndFruitsByEveryColor(SqlConnection conn)
    {
        using SqlCommand command = new($"SELECT Color,Count(Color) FROM VegetablesAndFruitsTable Group by Color", conn);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader[0]} - {reader[1]}");
        }
    }
    public static void ShowVegetablesAndFruitsByColoricityLowerThanChosen(SqlConnection conn)
    {
        Console.WriteLine("Enter coloricity -> ");
        int coloricity = Convert.ToInt32(Console.ReadLine());
        using SqlCommand command = new($"SELECT [Name] FROM VegetablesAndFruitsTable where [Coloricity] < {coloricity}", conn);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader[0]}");
        }
    }
    public static void ShowVegetablesAndFruitsByColoricityUpperThanChosen(SqlConnection conn)
    {
        Console.WriteLine("Enter coloricity -> ");
        int coloricity = Convert.ToInt32(Console.ReadLine());
        using SqlCommand command = new($"SELECT [Name] FROM VegetablesAndFruitsTable where [Coloricity] > {coloricity}", conn);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader[0]}");
        }
    }
    public static void ShowVegetablesAndFruitsByColoricityEqualsByChosen(SqlConnection conn)
    {
        Console.WriteLine("Enter coloricity -> ");
        int coloricity = Convert.ToInt32(Console.ReadLine());
        using SqlCommand command = new($"SELECT [Name] FROM VegetablesAndFruitsTable where [Coloricity] = {coloricity}", conn);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader[0]}");
        }
    }
    public static void ShowVegetablesAndFruitsWhitchAreRedOrYellow(SqlConnection conn)
    { 
        using SqlCommand command = new($"SELECT [Name] FROM VegetablesAndFruitsTable where Color ='yellow' or Color='red'", conn);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader[0]}");
        }
    }
}
