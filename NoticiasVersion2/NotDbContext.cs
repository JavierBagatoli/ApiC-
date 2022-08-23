using Microsoft.EntityFrameworkCore;
using NoticiasVersion2.models;

namespace NoticiasVersion2
{
    public class NotDbContext : DbContext
    {
        public NotDbContext(DbContextOptions opciones) : base(opciones) { 
        }
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Autor> Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelCreator) {
            new Noticia.Mapeo(modelCreator.Entity<Noticia>());
            new Autor.Mapeo(modelCreator.Entity<Autor>());
        } 
    }
}
