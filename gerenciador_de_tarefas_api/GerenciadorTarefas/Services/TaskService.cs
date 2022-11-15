using GerenciadorTarefas.Models;
using GerenciadorTarefas.Repositories;
using GerenciadorTarefas.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTarefas.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskTagRepository _taskTagRepository;

        public TaskService(ITaskRepository taskRepository,  ITaskTagRepository taskTagRepository)
        {
            _taskRepository = taskRepository;
            _taskTagRepository = taskTagRepository;
        }
        public void InsertTask(TaskView taskview)
        {
            Task task = new();
            task.title = taskview.title;
            task.description = taskview.description;
            task.hoursLong = taskview.hoursLong;
            task.executionDate = taskview.executionDate;
            task.creationDate = DateTime.Now;

            _taskRepository.InsertTask(task);

            foreach (var tag in taskview.selectedTagList)
            {
                TaskTag taskTag = new TaskTag()
                {
                    taskId = task.id,
                    tagId = tag.id,
                };
                _taskTagRepository.InsertTaskTag(taskTag);
            }
        }

        public void UpdateTask(long id, TaskView taskView)
        {
            var task = _taskRepository.GetTaskById(id);
            task.title = taskView.title;
            task.description = taskView.description;
            task.hoursLong = taskView.hoursLong;
            task.executionDate = taskView.executionDate;

            List<long> taskTags = _taskTagRepository.GetAllByTaskId(id);
            if( taskTags.Count > 0)
            {
                foreach (var idTaskTag in taskTags)
                {
                    TaskTag taskTag = _taskTagRepository.GetTaskTagById(idTaskTag);
                    _taskTagRepository.DeleteTaskTag(taskTag);
                }
            }
           
            foreach (var tag in taskView.selectedTagList)
            {
                TaskTag taskTag = new TaskTag()
                {
                    taskId = task.id,
                    tagId = tag.id,
                };
                _taskTagRepository.InsertTaskTag(taskTag);
            }
            _taskRepository.UpdateTask(task);
        }

        public void DeleteTask(long id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
            {
                throw new Exception("Trabalho não encontrado.");
            }
            _taskRepository.DeleteTask(task);
        }

        public TaskView GetTask(long id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null)
            {
                throw new Exception("Trabalho não encontrado.");
            }
            TaskView taskView = new TaskView();
            taskView.title = task.title;
            taskView.description = task.description;
            taskView.hoursLong = task.hoursLong;
            taskView.executionDate = task.executionDate;
            taskView.selectedTagList = task.tagList.Select(x => new TaskTagView
            {
                id = x.id,
                tagId = x.tagId,
            }).ToList();
            return taskView;
        }

        public List<TaskView> GetAll()
        {
            var tasks = _taskRepository.GetAll().Select(task => new TaskView()
            {
                id = task.id,
                title = task.title,
                description = task.description,
                hoursLong = task.hoursLong,
                executionDate = task.executionDate,
                selectedTagList = task?.tagList?.Select(x => new TaskTagView
                {
                    id = x.id,
                    tagId = x.tagId,
                }).ToList(),
            }).ToList();
            return tasks;
        }

    }

    public interface ITaskService
    {
        public void InsertTask(TaskView jobView);

        public void UpdateTask(long id, TaskView jobView);

        public void DeleteTask(long id);

        public TaskView GetTask(long id);

        public List<TaskView> GetAll();

    }
}
