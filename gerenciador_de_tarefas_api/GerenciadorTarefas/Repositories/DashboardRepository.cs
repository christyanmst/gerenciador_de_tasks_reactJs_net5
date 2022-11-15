using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GerenciadorTarefas.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly Context _dbContext;
        public DashboardRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public int tasksExecuted(DateTime date)
        {
            return _dbContext.Set<Task>().Where(s => s.executionDate.Year == date.Year && s.executionDate.Month == date.Month && s.executionDate.Day == date.Day).Select(s => s.executionDate).Count();
        }

        public int tagTaskExecuted(long id, DateTime date)
        {
            return _dbContext.Set<Task>().Where(s => s.executionDate <= date && s.tagList.Any(e=> e.tagId == id)).Select(s => s.title).Count();
        }
    }

    public interface IDashboardRepository
    {
        int tasksExecuted(DateTime date);

        int tagTaskExecuted(long id, DateTime date);
    }
}
