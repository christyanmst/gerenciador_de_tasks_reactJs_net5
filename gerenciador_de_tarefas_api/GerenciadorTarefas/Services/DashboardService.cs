using GerenciadorTarefas.Repositories;
using GerenciadorTarefas.Views;
using System;
using System.Collections.Generic;
using static GerenciadorTarefas.Views.GraphView;

namespace GerenciadorTarefas.Services
{
    public class DashboardService : IDashboardService
    {
        private IDashboardRepository _dashboardRepository;
        private ITagRepository _tagRepository;

        public DashboardService(IDashboardRepository dashboardRepository, ITagRepository tagRepository)
        {
            _dashboardRepository = dashboardRepository;
            _tagRepository = tagRepository;
        }

        private List<string> GetGraphDates()
        {
            var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            List<string> datesLabel = new List<string>();
            while (datesLabel.Count != 7)
            {
                datesLabel.Add(date.Day + "/" + date.Month);
                date = date.AddDays(-1);
            }
            datesLabel.Reverse();
            return datesLabel;
        }

        private List<string> GetLabelTag()
        {
            List<string> tags = new List<string>();
            var allTags = _tagRepository.GetAll();
            foreach (var tag in allTags)
            {
                tags.Add(tag.title);
            }

            return tags;
        }

        private List<int> GetTagData(Func<long, int> lambda)
        {
            List<int> graphDataList = new List<int>();
            var allTags = _tagRepository.GetAll();
            foreach (var tag in allTags)
            {
                int data = lambda(tag.id);
                graphDataList.Add(data);
            }

            return graphDataList;
        }

        private List<int> GetTaskData(Func<DateTime, int> lambda)
        {
            List<int> graphDataList = new List<int>();
            var date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            for (int i = 0; i < 7; i++)
            {
                int data = lambda(date);
                date = date.AddDays(-1);
                graphDataList.Add(data);
            }
            graphDataList.Reverse();
            return graphDataList;
        }

        public GraphView GetTaskGraph()
        {
            GraphView graph = new GraphView(GetGraphDates(), "Tasks", GetTaskData((x) => _dashboardRepository.tasksExecuted(x)));

            return graph;
        }

        public GraphView GetTagsGraph()
        {
            var date = DateTime.Now;
            GraphView graph = new GraphView(GetLabelTag(), "Tasks", GetTagData((x) => _dashboardRepository.tagTaskExecuted(x, date)));

            return graph;
        }
    }

    public interface IDashboardService
    {
        public GraphView GetTaskGraph();
        public GraphView GetTagsGraph();
    }
}
