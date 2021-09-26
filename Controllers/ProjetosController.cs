using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDeProjetos.Models;
using GerenciadorDeProjetos.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProjetos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : ControllerBase
    {
        private readonly DataContext _context;

        // Construtor
        public ProjetosController(DataContext context) => _context = context;

        // POST : /api​/Projetos
        [HttpPost]
        public Projeto Create(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
            return projeto;
        }

        // GET : /api​/Projetos
        [HttpGet]
        public List<Projeto> Listar() => _context.Projetos.ToList();

        // GET : /api​/Projetos
        [HttpGet]
        [Route("getbyid/{id}")]
        public Projeto GetById([FromRoute]int id)
        {
            return null;
        }
    
    }
}