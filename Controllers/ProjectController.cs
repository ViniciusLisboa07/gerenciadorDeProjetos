using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            int userId = project.UserId;
            project.User = _context.User.Find(userId);
            _context.Project.Add(project);
            _context.SaveChanges();
            return Created("", project);
        }

        //GET: api/produto/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => 
            Ok(_context.Project
            .Include(project => project.User)
            .ToList());

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
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            //Expressão lambda
            //Buscar um produto pelo nome
            Project project = _context.Project.FirstOrDefault
            (
                project => project.Id == id
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


        [HttpGet]
        [Route("calc-percentage/{id}")]
        public IActionResult CalcPorcent([FromRoute] int id)
        {
            //Buscar um produto pela chave primária
            var tasksByProject = _context.Task.ToList().Where(task => task.ProjectId == id);
            var finishedTasks = tasksByProject.Where(task => task.End == true);

            var percentage = (100 * finishedTasks.Count()) / tasksByProject.Count();

            // Project project = _context.Project.Find(id);
            if (percentage == null)
            {
                return NotFound();
            }
            return Ok(percentage);
        }

        [HttpGet]
        [Route("is-late/{id}")]
        public IActionResult IsLate([FromRoute] int id)
        {
            //Buscar um produto pela chave primária
            var project = _context.Project.Find(id);
            var tasksByProject = _context.Task.ToList().Where(task => task.ProjectId == id);
            var LateTasks = tasksByProject.Where(task => task.EndDate > project.EndDate).FirstOrDefault();

            // Project project = _context.Project.Find(id);
            if (LateTasks != null && LateTasks.EndDate > project.EndDate)
            {   
                return Ok(true);
            } else {
                return Ok(false);
            }
        }

    }
}