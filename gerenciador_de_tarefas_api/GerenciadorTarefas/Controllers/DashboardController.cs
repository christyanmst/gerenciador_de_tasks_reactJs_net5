using GerenciadorTarefas.Services;
using GerenciadorTarefas.Views;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        [Route("graphDataTasksExecuted")]
        public GraphView GetTaskGraph()
        {
            return _dashboardService.GetTaskGraph();
        }

        [HttpGet]
        [Route("graphDataTagTasksExecuted")]
        public GraphView GetTagTaskGraph()
        {
            return _dashboardService.GetTagsGraph();
        }
    }
}
