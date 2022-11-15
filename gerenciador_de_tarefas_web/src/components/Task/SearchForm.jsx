import { useState, useEffect } from "react";
import { Button, Card, Input, InputGroup, Row, Col } from "reactstrap";
import { getAll, deleteJob } from "../../services/taskServices";
import Router from "next/router";
import { TableTask } from "../../utils/TableTask";

export default function Home() {
  const [taskList, setTaskList] = useState([]);
  const [renderPage, setRenderPage] = useState(false);
  const [filterTitle, setFilterTitle] = useState();

  useEffect(() => {
    if (filterTitle) {
      getAll().then((res) =>
        setTaskList(
          res.data.filter((t) =>
            t.title.toLowerCase().includes(filterTitle.toLowerCase())
          )
        )
      );
      setRenderPage(false);
    } else {
      getAll().then((res) => setTaskList(res.data));
      setRenderPage(false);
    }
  }, [renderPage]);

  function handleDelete(job) {
    deleteJob(job)
      .then(() => setRenderPage(true))
      .catch((err) => console.log(err));
  }

  function searchFilter(title) {
    setFilterTitle(title);
    setRenderPage(true);
  }

  return (
    <>
      <div className="container">
        <Card className="cardInput">
          <div className="title">
            <h3>Visualizando Tasks</h3>
          </div>
          <Row className="searchBar">
            <Col xs={6}>
              <InputGroup>
                <Input
                  id="title"
                  className={"searchInput"}
                  placeholder="Título"
                />
                <Button
                  className="buttonInput"
                  onClick={() => {
                    searchFilter(document.querySelector("#title").value);
                  }}
                >
                  Pesquisar
                </Button>
              </InputGroup>
            </Col>
          </Row>

          <Row>
            <Col xs={6}>
              <Button
                title="Novo"
                className="button"
                onClick={() => Router.push("/task/create")}
              >
                Novo
              </Button>
              <Button
                title="Voltar"
                className="button"
                onClick={() => Router.push("/dashboard")}
              >
                Voltar
              </Button>
            </Col>
          </Row>
          <TableTask List={taskList} handleDelete={handleDelete} />
        </Card>
      </div>
    </>
  );
}
