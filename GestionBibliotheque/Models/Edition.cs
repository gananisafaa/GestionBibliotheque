
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionBibliotheque.Models
{
    public class Edition
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatePublication { get; set; }
        public int NbPages { get; set; }
        public int NbCopies { get; set; }
        [NotMapped]
        public ICollection<Oeuvre> Oeuvres { get; set; }

        public Edition()
        {
        }
    }
}
