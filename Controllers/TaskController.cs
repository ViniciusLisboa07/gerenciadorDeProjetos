using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Models;
using Microsoft.AspNetCore.Mvc;

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
            _context.Task.Add(task);
            _context.SaveChanges();
            return Created("", task);
        }

        //GET: api/produto/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Task.ToList());

        //GET: api/produto/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um produto pela chave primária
            Task task = _context.Task.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        //DELETE: api/produto/delete/
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete([FromRoute] string name)
        {
            //Expressão lambda
            //Buscar um produto pelo nome
            Task task = _context.Task.FirstOrDefault
            (
                task => task.Name == name
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