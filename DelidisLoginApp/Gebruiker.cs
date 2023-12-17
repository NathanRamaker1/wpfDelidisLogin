using System.ComponentModel.DataAnnotations;

namespace DelidisLoginApp
{
    public class Gebruiker
    {

        [Key]
        public string Id { get; set; }

        public string Gebruikersnaam { get; set; }

        public string Paswoord { get; set; }


    }
}