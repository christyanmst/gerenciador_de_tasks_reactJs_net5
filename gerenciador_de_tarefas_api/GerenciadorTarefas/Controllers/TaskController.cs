using GerenciadorTarefas.Services;
using GerenciadorTarefas.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public ActionResult<List<TaskView>> Get()
        {
            return _taskService.GetAll();

        }
        [HttpPost]
        public ActionResult<TaskView> Post([FromBody] TaskView taskView)
        {
            _taskService.InsertTask(taskView);
            return taskView;
        }

        [HttpPut, Route("{id}")]
        public ActionResult<TaskView> Put([FromRoute] long id, [FromBody] TaskView jobView)
        {
            _taskService.UpdateTask(id, jobView);
            return jobView;
        }

        [HttpPut, Route("delete/{id}")]
        public ActionResult<TaskView> Delete([FromRoute] long id)
        {
            _taskService.DeleteTask(id);
            return Ok();
        }

        [HttpGet, Route("{id}")]
        public ActionResult<TaskView> Get([FromRoute] long id)
        {
            return _taskService.GetTask(id);
           
        }

    }
}
