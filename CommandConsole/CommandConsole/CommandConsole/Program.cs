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

     
        MostraLivros();

        // string strcon = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\fabri\\Documents\\Command.mdf;Integrated Security = True";
        // SqlConnection conn = new SqlConnection(strcon);


    }

    public static void MostraLivros()
    {
        BookRepositorioSql repo = new BookRepositorioSql();

       
        foreach (var b in repo.Books)
        {
            Console.WriteLine(b + b.getAuthorNames());

        }


        Console.WriteLine("\nDone. Press enter.");
        Console.ReadLine();

    }

}

