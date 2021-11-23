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

        //POST: api/task/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Task task)
        {
            int projectId = task.ProjectId;
            task.Project = _context.Project.Find(projectId);
            if(task.StartDate < task.Project.StartDate || task.EndDate > task.Project.EndDate){
                return NotFound("A data de inicio e final devem estar dentro do periodo do projeto");
            }
            
            _context.Task.Add(task);
            _context.SaveChanges();
            return Created("", task);
        }

        //GET: api/task/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => 
                Ok(_context.Task
                .Include(task => task.Project)
                .ToList());

        //GET: api/task/listbyproductid/1
        [HttpGet]
        [Route("listbyprojectid/{projectId}")]
        public IActionResult ListByProjectId([FromRoute] int projectId)
        {
            //Buscar um project pela chave primária
            var tasks = _context.Task.ToList();
            var tasksByID = tasks.Where(task => task.ProjectId == projectId);
            
            if (tasksByID == null)
            {
                return NotFound();
            }
            return Ok(tasksByID);
        }

        //GET: api/task/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById() => 
                Ok(_context.Task
                .Include(task => task.Project)
                .ToList());


        //DELETE: api/task/delete/
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            //Expressão lambda
            //Buscar um project pelo nome
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

        //PUT: api/task/create
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