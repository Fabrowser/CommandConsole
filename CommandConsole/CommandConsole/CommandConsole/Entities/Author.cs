using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;

namespace CommandConsole.Entities
{
    public class Author
    {
        public int IdAutor;
        public string Name;
        public string Email;
        public string Gender;

        public Author()
        {
        }

        public Author(int id, string name, string email, string gender)
        {
            IdAutor = id;
            Name = name;
            Email = email;
            Gender = gender;
        }

        public override string ToString()
        {
            return "Autor: " + Name;
        }
    }

}

