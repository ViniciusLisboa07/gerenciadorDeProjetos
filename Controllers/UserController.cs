using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Controller]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        //Construtor
        public UserController(DataContext context) => _context = context;

        //POST: api/produto/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return Created("", user);
        }

        //GET: api/produto/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.User.ToList());

        //GET: api/produto/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um produto pela chave primária
            User user = _context.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //DELETE: api/produto/delete/
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            //Expressão lambda
            //Buscar um produto pelo nome
            User user = _context.User.FirstOrDefault
            (
                user => user.Id == id
            );
            if (user == null)
            {
                return NotFound();
            }
            _context.User.Remove(user);
            _context.SaveChanges();
            return Ok(_context.User.ToList());
        }

        //PUT: api/produto/update
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
            return Ok(user);
        }


    }
}