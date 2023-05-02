using AppFruitsAndVegetables;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Program;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Choose opption:" +
                        "\nOpen connection - \'1\'" +
                        "\nClose connection - \'2\'");

        int input = Convert.ToInt32(Console.ReadLine());
        ConfigurationBuilder builder = new();
        builder.AddJsonFile("appsettings.json");
        var res = builder.Build();
        using SqlConnection conn = new(res.GetConnectionString("VegetablesAndFruits"));
        if (input == 1)
        {
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                Console.Clear();
                Console.WriteLine(" - - - - - - - - - - Lucky connection!) - - - - - - - - - - \n");
                Console.WriteLine("Choose opption:" +
                "\n0) Show all info" +
                "\n1) Show all names of fruits and vegetables" +
                "\n2) Show all colors" +
                "\n3) Show max coloricity" +
                "\n4) Show min coloricity" +
                "\n5) Show average coloricity" +

                "\n6) Show count of vegetables" +
                "\n7) Show count of fruits" +
                "\n8) Show count of fruits and vegetables by color" +
                "\n9) Show сount of vegetables and fruits by every color" +
                "\n10) Show vegetables and fruits by coloricity lower than chosen" +
                "\n11) Show vegetables and fruits by coloricity upper than chosen" +
                "\n12) Show vegetables and fruits by coloricity equals by chosen" +
                "\n13) Show vegetables and fruits whitch are red or yellow" +
                "\n14) Close connection");

                input = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (input)
                {
                    case 0:
                        ShowFunctions.ShowAllInfo(conn);
                        break;
                    case 1:
                        ShowFunctions.ShowAllNames(conn);
                        break;
                    case 2:
                        ShowFunctions.ShowAllColors(conn);
                        break;
                    case 3:
                        ShowFunctions.ShowMaxColoricity(conn);
                        break;
                    case 4:
                        ShowFunctions.ShowMinColoricity(conn);
                        break;
                    case 5:
                        ShowFunctions.ShowAverageColoricity(conn);
                        break;

                    case 6:
                        ShowFunctions.ShowCountOfVegetables(conn);
                        break;
                    case 7:
                        ShowFunctions.ShowCountOfFruits(conn);
                        break;
                    case 8:
                        ShowFunctions.ShowCountOfVegetablesAndFruitsByColor(conn);
                        break;
                    case 9:
                        ShowFunctions.ShowCountOfVegetablesAndFruitsByEveryColor(conn);
                        break;
                    case 10:
                        ShowFunctions.ShowVegetablesAndFruitsByColoricityLowerThanChosen(conn);
                        break;
                    case 11:
                        ShowFunctions.ShowVegetablesAndFruitsByColoricityUpperThanChosen(conn);
                        break;
                    case 12:
                        ShowFunctions.ShowVegetablesAndFruitsByColoricityEqualsByChosen(conn);
                        break;
                    case 13:
                        ShowFunctions.ShowVegetablesAndFruitsWhitchAreRedOrYellow(conn);
                        break;
                    case 14:
                        conn.Close();
                        if (conn.State == System.Data.ConnectionState.Closed) Console.WriteLine("Lucky disconnection!");
                        else Console.WriteLine("Unlucky disconnection!");
                        break;
                    default:
                        Console.WriteLine("Error! You should choose 0 to 14! ");
                        break;
                }
            }
            else Console.WriteLine("Unlucky connection!");
        }
        else if (input == 2)
        {
            conn.Close();
            if (conn.State == System.Data.ConnectionState.Closed) Console.WriteLine("Lucky disconnection!");
            else Console.WriteLine("Unlucky disconnection!");
        }
        else Console.WriteLine("Error! You have to choose 1 or 2!");
    }
}