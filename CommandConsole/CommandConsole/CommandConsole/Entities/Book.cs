using CommandConsole.Entities;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace CommandConsole.Entities
{

    public class Book
    {

        public int IdLivro;
        public string Name;
        public double Price;
        public int Qty;
        public List<Author> Authors;


        public Book()
        {
        }

        public Book(int id, string name, double price, int qty,List<Author> autores)
        {
            IdLivro = id;
            Name = name;
            Price = price;
            Qty = qty;
            Authors = new List<Author>(autores);
        }

        public Book(int id, string name, List<Author> listaAuthors, double price)
        {
            IdLivro = id;
            Name = name;
            Price = price;
            Authors = listaAuthors;
        }

        public Book(int id, string name, List<Author> listaAuthors, double price, int qty) : this(id, name, listaAuthors, price)
        {
            Qty = qty;
        }
        public String getName()
        {
            return Name;
        }

        public List<Author> getAuthor()
        {
            return Authors;
        }

        public Double getPrice()
        {
            return Price;
        }

        public void setPrice(double price)
        {
            price = this.Price;
        }

        public int getQty()
        {
            return this.Qty;
        }

        public void setQty(int qty)
        {

            qty = this.Qty;

        }

        public String getAuthorNames()
        {
            StringBuilder sbAutores = new StringBuilder();
            foreach (Author autor in Authors)
            {

                sbAutores.Append("Nome: " + autor.Name + "\n");

            }
            return "Autores: \n" + sbAutores.ToString();
        }


        public bool PesquisaAutorNoLivro(int id)
        {
            foreach (Author autor in Authors)
            {

                if (autor.IdAutor == id)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            return true;

        }

        public override string ToString()
        {
            return "\n---------------------------\n" +
                    "LIVRO COD: " + IdLivro +
                    "\nName: " + Name +
                    "\n--------------------------\n" +
                    "Price: " + Price +
                    "\nQuantity: " + Qty +
                    "\n--------------------------\n";
        }

    }

}

