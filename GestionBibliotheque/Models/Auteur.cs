using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionBibliotheque.Models
{
    public class Auteur
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        [NotMapped]
        public ICollection<Oeuvre> Oeuvres { get; set; }
        public Auteur()
        {
        }
    }
}
