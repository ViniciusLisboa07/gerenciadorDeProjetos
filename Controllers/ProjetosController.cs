using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDeProjetos.Models;

using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeProjetos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : ControllerBase
    {
        [HttpPost]
        public Projeto Create(Projeto projeto)
        {
            projeto.Nome += "qqq";
            return projeto;
        }
    }
}