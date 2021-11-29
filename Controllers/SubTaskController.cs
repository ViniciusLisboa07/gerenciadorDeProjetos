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
    [Route("api/subtask")]
    public class SubtaskController : ControllerBase
    {
        private readonly DataContext _context;

        //Construtor
        public SubtaskController(DataContext context) => _context = context;

        //POST: api/produto/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Subtask subtask)
        {
            int taskId = subtask.TaskId;
            subtask.Task = _context.Task.Find(taskId);
            _context.Subtask.Add(subtask);
            _context.SaveChanges();
            return Created("", subtask);
        }

        //GET: api/produto/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => 
                Ok(_context.Subtask
                .Include(subtask => subtask.Task)
                .Include(subtask => subtask.Task.Project)
                .Include(subtask => subtask.Task.Project.User)
                .ToList());

        //GET: api/produto/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um produto pela chave primária
            Subtask subtask = _context.Subtask
            .Include(subtask => subtask.Task)
            .FirstOrDefault(x=> x.Id == id);
            if (subtask == null)
            {
                return NotFound();
            }
            return Ok(subtask);
        }

        //GET: api/subtask/listbyproductid/1
        [HttpGet]
        [Route("listbytaskid/{taskId}")]
        public IActionResult GetByTaskId([FromRoute] int taskId)
        {
            //Buscar um produto pela chave primária
            List<Subtask> subtask = _context.Subtask
            .Include(subtask => subtask.Task)
            .Where(x => x.TaskId == taskId)
            .ToList();

            if (subtask == null)
            {
                return NotFound();
            }
            return Ok(subtask);
        }


        //DELETE: api/produto/delete/
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            //Expressão lambda
            //Buscar um produto pelo nome
            Subtask subtask = _context.Subtask.FirstOrDefault
            (
                subtask => subtask.Id == id
            );
            if (subtask == null)
            {
                return NotFound();
            }
            _context.Subtask.Remove(subtask);
            _context.SaveChanges();
            return Ok(_context.Subtask.ToList());
        }

        //PUT: api/produto/create
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Subtask subtask)
        {
            int taskId = subtask.TaskId;
            subtask.Task = _context.Task.Find(taskId);
            _context.Subtask.Update(subtask);
            _context.SaveChanges();
            return Ok(subtask);
        }


    }
}