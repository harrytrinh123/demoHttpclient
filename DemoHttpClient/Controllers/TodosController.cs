using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DemoHttpClient.Models;
using DemoHttpClient.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DemoHttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        ITodoService _todoService;
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet()]
        public async Task<List<Models.Todo>> Get_All_Todos()
        {
            var tasks = await _todoService.GetAllAsync();

            return tasks;
        }

        [HttpGet("{todoID}", Name = "GetTodo")]
        public async Task<Models.Todo> Get_Todo_By_ID(int todoID)
        {
            var task = await _todoService.GetTodoAsync(todoID);
            return task;
        }

        [HttpPost()]
        //public IActionResult Create_Todo([FromBody] Todo todoToCreate)
        //{
        //   var _ = _todoService.CreateTodoAsync(todoToCreate);
        //    return CreatedAtRoute("GetTodo", new { id = todoToCreate.Id }, todoToCreate);
        //}
        public async Task<Todo> Create_Todo([FromForm] Todo todoToCreate)
        {
            return await _todoService.CreateTodoAsync(todoToCreate);
        }

        [HttpPut("{todoID}")]
        public async Task<Todo> Update_Todo([FromForm] Todo todoToUpdate)
        {
            return await _todoService.UpdateTodoAsync(todoToUpdate);
        }

        [HttpDelete("{todoID}")]
        public async Task Delete_Todo(int todoID)
        {
            await _todoService.DeleteTodoAsync(todoID);

        }
    }
}
