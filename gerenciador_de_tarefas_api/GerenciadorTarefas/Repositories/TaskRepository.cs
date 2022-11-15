using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GerenciadorTarefas.Repositories
{
    public class TaskRepository : ITaskRepository

    {
        private readonly Context _dbContext;

        public TaskRepository(Context context)
        {
            _dbContext = context;
        }

        public Task GetTaskById(long id)
        {
            return  _dbContext.Tasks.Include(c => c.tagList).FirstOrDefault(x => x.id == id);
        }

        public List<Task> GetAll()
        {
            return _dbContext.Tasks.Include(c => c.tagList).ToList();
        }

        public void InsertTask(Task task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();

        }
        public void UpdateTask(Task task)
        {
            _dbContext.Set<Task>().Update(task);
            _dbContext.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            _dbContext.Set<Task>().Remove(task);
            _dbContext.SaveChanges();
        }
    }
    public interface ITaskRepository
    {

        public void InsertTask(Task task);
        public void UpdateTask(Task task);
        public void DeleteTask(Task task);
        public Task GetTaskById(long id);

        public List<Task> GetAll();
       
    }
}
