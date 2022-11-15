using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTarefas.Repositories
{
    public class TaskTagRepository : ITaskTagRepository
    {
        private readonly Context _dbContext;

        public TaskTagRepository(Context context)
        {
            _dbContext = context;
        }
        public void DeleteTaskTag(TaskTag taskTag)
        {
            _dbContext.Set<TaskTag>().Remove(taskTag);
            _dbContext.SaveChanges();
        }

        public List<TaskTag> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TaskTag GetTaskTagById(long id)
        {
            return _dbContext.TaskTags.FirstOrDefault(x => x.id == id);
        }

        public void InsertTaskTag(TaskTag taskTag)
        {
            _dbContext.TaskTags.Add(taskTag);
            _dbContext.SaveChanges();
        }

        public void UpdateTaskTag(TaskTag taskTag)
        {
            throw new System.NotImplementedException();
        }

        public List<long> GetAllByTaskId(long id)
        {
            return _dbContext.Set<TaskTag>().Where(x => x.taskId == id).Select(x => x.id).ToList();
        }
    }

    public interface ITaskTagRepository
    {
        public void InsertTaskTag(TaskTag taskTag);
        public void UpdateTaskTag(TaskTag taskTag);
        public void DeleteTaskTag(TaskTag taskTag);
        public TaskTag GetTaskTagById(long id);
        public List<TaskTag> GetAll();
        public List<long> GetAllByTaskId(long id);
    }
}
