using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GestionBibliotheque.Models;

namespace GestionBibliotheque.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GestionBibliotheque.Models.Genre> Genre { get; set; }
        public DbSet<GestionBibliotheque.Models.Oeuvre> Oeuvre { get; set; }
        public DbSet<GestionBibliotheque.Models.Edition> Edition { get; set; }
        public DbSet<GestionBibliotheque.Models.Auteur> Auteur { get; set; }
        public DbSet<GestionBibliotheque.Models.Emprunteur> Emprunteur { get; set; }
    }
}
