using DemoHttpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoHttpClient.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo> GetTodoAsync(int id);
        Task<Todo> CreateTodoAsync(Todo task);
        Task<Todo> UpdateTodoAsync(Todo task);
        Task DeleteTodoAsync(int id);
    }
}
