using GerenciadorTarefas.Services;
using GerenciadorTarefas.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpGet]
        public ActionResult<List<TagView>> Get()
        {
            return _tagService.GetAll();

        }
        [HttpPost]
        public ActionResult<TagView> Post([FromBody] TagView taskView)
        {
            _tagService.InsertTag(taskView);
            return taskView;
        }

        [HttpPut, Route("{id}")]
        public ActionResult<TagView> Put([FromRoute] long id, [FromBody] TagView jobView)
        {
            _tagService.UpdateTag(id, jobView);
            return jobView;
        }

        [HttpPut, Route("delete/{id}")]
        public ActionResult<TagView> Delete([FromRoute] long id)
        {
            _tagService.DeleteTag(id);
            return Ok();
        }

        [HttpGet, Route("{id}")]
        public ActionResult<TagView> Get([FromRoute] long id)
        {
            return _tagService.GetTag(id);

        }

    }
}
