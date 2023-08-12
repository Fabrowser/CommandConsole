using CommandConsole;
using CommandConsole.Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

internal class Program
{
    private static void Main(string[] args)
    {

        // string strcon = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\fabri\\Documents\\Command.mdf;Integrated Security = True";
        // SqlConnection conn = new SqlConnection(strcon);

        BookRepositorioSql bookRepositorio = new BookRepositorioSql();

        foreach (var book in bookRepositorio.books)
        {

            Console.WriteLine(book);

        }
        Console.WriteLine("\nDone. Press enter.");
        Console.ReadLine();


    }
}
