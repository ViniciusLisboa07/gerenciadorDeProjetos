using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Controller]
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext _context;

        //Construtor
        public ProjectController(DataContext context) => _context = context;

        //POST: api/produto/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Project project)
        {
            _context.Project.Add(project);
            _context.SaveChanges();
            return Created("", project);
        }

        //GET: api/produto/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Project.ToList());

        //GET: api/produto/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um produto pela chave primária
            Project project = _context.Project.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        //GET: api/produto/getbyuser/Maria
        [HttpGet]
        [Route("getbyuser/{name}")]
        public IActionResult GetByUser([FromRoute] string name)
        {
            //Buscar um produto pela chave primária
            Project project = _context.Project.FirstOrDefault
            (
                project => project.Name == name
            );
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        //DELETE: api/produto/delete/
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete([FromRoute] string name)
        {
            //Expressão lambda
            //Buscar um produto pelo nome
            Project project = _context.Project.FirstOrDefault
            (
                project => project.Name == name
            );
            if (project == null)
            {
                return NotFound();
            }
            _context.Project.Remove(project);
            _context.SaveChanges();
            return Ok(_context.Project.ToList());
        }

        //PUT: api/produto/create
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Project project)
        {
            _context.Project.Update(project);
            _context.SaveChanges();
            return Ok(project);
        }


    }
}