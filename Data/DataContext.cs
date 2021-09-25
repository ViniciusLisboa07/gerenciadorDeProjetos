using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeProjetos.Models;

namespace GerenciadorDeProjetos.Data
{
    public class DataContext : DbContext
    {
        // Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options) {  }

        // props -> tbls no banco
        public DbSet<Projeto> Projetos { get; set; }
    }
}