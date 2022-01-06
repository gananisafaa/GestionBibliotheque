using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionBibliotheque.Models
{
    public class Oeuvre
    {
        [Key]
        public int Id { get; set; }
        public string Titre { get; set; }
        public int AuteurID { get; set; }
        public  Auteur Auteur { get; set; }
        public int GenreID { get; set; }

        public Genre Genre { get; set; }
        public ICollection<Edition> Editions { get; set; }
        public string Langue { get; set; }
        public string Resume { get; set; }

        public Oeuvre()
        {
        }
    }
}
