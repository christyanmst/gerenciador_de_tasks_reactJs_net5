import React from "react";
import { Chart as ChartJS, CategoryScale, LinearScale, PointElement, LineElement, Title, Tooltip, Legend,
} from "chart.js";
const Graph = ({ title, graphData, Chart }) => {
  ChartJS.register(CategoryScale,LinearScale, PointElement, LineElement, Title, Tooltip, Legend);
  return (
    <>
      <h2>{title}</h2>
      <div>
        <Chart
          data={{
            labels: graphData.graphLabel,
            datasets: [{
                label: graphData.label,
                data: graphData.data,
                backgroundColor: '#4169E1',
                borderColor: '#4169E1',
                borderWidth: 1
            }]
          }}
          height={550}
          options={{
            maintainAspectRatio: false,
            scales: {
            },
          }}
        />
      </div>
    </>
  );
};

export default Graph;
