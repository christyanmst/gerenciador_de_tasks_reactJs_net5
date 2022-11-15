using System;
using System.Collections.Generic;

namespace GerenciadorTarefas.Views
{
    public class TaskView
    {
        public long id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public decimal hoursLong { get; set; }

        public bool executed { get; set; }

        public DateTime executionDate { get; set; }

        public List<TaskTagView> selectedTagList { get; set; }
    }
}
