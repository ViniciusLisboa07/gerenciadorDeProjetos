using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        //Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Lista de propriedades das classes de modelo que vão virar tabelas no banco
        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Task> Task { get; set; }
    }
}