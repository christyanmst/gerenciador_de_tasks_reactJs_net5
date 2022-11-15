import { Card, Row, Col } from "reactstrap";
import { useState, useEffect } from "react";
import { Line } from "react-chartjs-2";
import Chart from "../utils/Chart";

import { getGraphDataTasksExecuted, getGraphDataTagTasksExecuted } from "../services/dashboardServices";

export default function Dashboard() {
  const [taskExecutedList, setTaskExecutedList] = useState([]);
  const [tagTaskExecutedLis, setTagTaskExecutedList] = useState([]);

  useEffect(() => {
    getGraphDataTasksExecuted().then((res) => setTaskExecutedList(res.data));
    getGraphDataTagTasksExecuted().then((res) => setTagTaskExecutedList(res.data));
  }, []);


  return (
    <>
      <div className="containerGraph">
        <div className="title"><h3>Dashboard</h3></div>
        <Row xs={2}>
          <Col>
            <Card className="cardGraph">
              <Chart
                title={"Tasks Resolvidas"}
                graphData={taskExecutedList}
                Chart={Line}
              ></Chart>
            </Card>
          </Col>
          <Col>
            <Card className="cardGraph">
              <Chart
                title={"Tags com mais Tasks resolvidas"}
                graphData={tagTaskExecutedLis}
                Chart={Line}
              ></Chart>
            </Card>
          </Col>
        </Row>
      </div>
    </>
  );
}
