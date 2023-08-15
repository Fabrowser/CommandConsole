using CommandConsole.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal class BookRepositorioSql
    {
        public List<Book> Books = new List<Book>();
        public List<Author> Authors = new List<Author>();

        public BookRepositorioSql()
        {


            try
            {
                Conectar con = new Conectar();

                using (SqlConnection connection = new SqlConnection(con.ConexaoDb().ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Livros");

                    //Query com o comando de MUITOS PARA MUITOS
                    String sql = "select l.id_livro, l.nm_livro, l.price, l.qty, a.id_author,a.name_author,a.email, " +
                        "a.gender from livro as l inner join livro_autor on l.id_livro = livro_autor.id_livro \r\n " +
                        " inner join autor as a on a.id_author = livro_autor.id_autor\r\n   ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("livros Buscados no BD SQL --- Relação MUITOS PARA MUITOS");

                            while (reader.Read())
                            {

                                int idLivro = reader.GetInt32(0);
                                string nomeLivro = reader.GetString(1);
                                double precoLivro = reader.GetFloat(2);
                                int qtdLivro = reader.GetInt32(3);

                                int idAutor = reader.GetInt32(4);
                                String nomeAutor = reader.GetString(5);
                                String emailAutor = reader.GetString(6);
                                String GeneroAutor = reader.GetString(7);

                                if (Books.Find(l => l.IdLivro == idLivro) == null)
                                {
                                    Book livro = new Book(idLivro, nomeLivro, precoLivro, qtdLivro, Authors);
                                    Books.Add(livro);
                                    Author autor = new Author(idAutor, nomeAutor, emailAutor, GeneroAutor);
                                    livro.Authors.Add(autor);


                                }
                                else
                                {

                                    Author autor = new Author(reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));

                                    foreach (Book book in Books)
                                    {
                                        if(book.IdLivro == idLivro)
                                        {
                                            book.Authors.Add(autor);
                                        }

                                    }


                                }
                            }
                        }

                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}