using System;
using System.Collections.Generic;

namespace GerenciadorTarefas.Views
{
    public class GraphView
    {
        public List<String> graphLabel { get; set; }

        public string label { get; set; }

        public List<int> data { get; set; }

        public GraphView(List<String> graphLabel, string label, List<int> data)
        {
            this.graphLabel = graphLabel;
            this.label = label;
            this.data = data;
        }

    }
}


