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
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;

        //Construtor
        public TaskController(DataContext context) => _context = context;

        //POST: api/produto/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Task task)
        {
            int projectId = task.ProjectId;
            task.Project = _context.Project.Find(projectId);
            _context.Task.Add(task);
            _context.SaveChanges();
            return Created("", task);
        }

        //GET: api/produto/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => 
                Ok(_context.Task
                .Include(task => task.Project)
                .ToList());

        //GET: api/produto/getbyid/1
        [HttpGet]
        [Route("getbyid/{projectId}")]
        public IActionResult GetById([FromRoute] int projectId)
        {
            //Buscar um produto pela chave primária
            var tasks = _context.Task.ToList();
            tasks.Where(task => task.ProjectId == projectId);
            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        //GET: api/task/listbyproductid/1
        [HttpGet]
        [Route("listbyproductid/{id}")]
        public IActionResult ListByProductId() => 
                Ok(_context.Task
                .Include(task => task.Project)
                .ToList());


        //DELETE: api/produto/delete/
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            //Expressão lambda
            //Buscar um produto pelo nome
            Task task = _context.Task.FirstOrDefault
            (
                task => task.Id == id
            );
            if (task == null)
            {
                return NotFound();
            }
            _context.Task.Remove(task);
            _context.SaveChanges();
            return Ok(_context.Task.ToList());
        }

        //PUT: api/produto/create
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Task task)
        {
            _context.Task.Update(task);
            _context.SaveChanges();
            return Ok(task);
        }


    }
}