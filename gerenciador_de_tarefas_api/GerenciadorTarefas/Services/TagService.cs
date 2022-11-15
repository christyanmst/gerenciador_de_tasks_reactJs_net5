using GerenciadorTarefas.Models;
using GerenciadorTarefas.Repositories;
using GerenciadorTarefas.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTarefas.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public void InsertTag(TagView tagView)
        {
            Tag tag = new();
            tag.title = tagView.title;
            tag.description = tagView.description;
            tag.creationDate = DateTime.Now;
            _tagRepository.InsertTag(tag);
        }

        public void UpdateTag(long id, TagView tagView)
        {
            var tag = _tagRepository.GetTagById(id);
            tag.title = tagView.title;
            tag.description = tagView.description;
            _tagRepository.UpdateTag(tag);
        }

        public void DeleteTag(long id)
        {
            var tag = _tagRepository.GetTagById(id);
            if (tag == null)
            {
                throw new Exception("Tag não encontrada.");
            }
            _tagRepository.DeleteTag(tag);
        }
        public TagView GetTag(long id)
        {
            var tag = _tagRepository.GetTagById(id);
            if (tag == null)
            {
                throw new Exception("Trabalho não encontrado.");
            }
            TagView tagView = new TagView();
            tagView.id = tag.id;
            tagView.title = tag.title;
            tagView.description = tag.description;
            return tagView;
        }

        public List<TagView> GetAll()
        {
            var tags = _tagRepository.GetAll().Select(tag => new TagView()
            {
                id = tag.id,
                title = tag.title,
                description = tag.description,
            }).ToList();

            return tags;
        }

    }

    public interface ITagService
    {
        public void InsertTag(TagView tagView);

        public void UpdateTag(long id, TagView tagView);

        public void DeleteTag(long id);

        public TagView GetTag(long id);

        public List<TagView> GetAll();
    }
}
