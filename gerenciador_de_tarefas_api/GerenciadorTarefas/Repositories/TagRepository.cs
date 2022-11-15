using GerenciadorTarefas.Data;
using GerenciadorTarefas.Models;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTarefas.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly Context _dbContext;

        public TagRepository(Context context)
        {
            _dbContext = context;
        }

        public Tag GetTagById(long id)
        {
            return _dbContext.Tags.FirstOrDefault(x => x.id == id);
        }

        public List<Tag> GetAll()
        {
            return _dbContext.Tags.ToList();
        }

        public void InsertTag(Tag tag)
        {
            _dbContext.Tags.Add(tag);
            _dbContext.SaveChanges();

        }
        public void UpdateTag(Tag tag)
        {
            _dbContext.Set<Tag>().Update(tag);
            _dbContext.SaveChanges();
        }

        public void DeleteTag(Tag tag)
        {
            _dbContext.Set<Tag>().Remove(tag);
            _dbContext.SaveChanges();
        }
    }

    public interface ITagRepository
    {
        public void InsertTag(Tag tag);
        public void UpdateTag(Tag tag);
        public void DeleteTag(Tag tag);
        public Tag GetTagById(long tag);
        public List<Tag> GetAll();
    }
}
