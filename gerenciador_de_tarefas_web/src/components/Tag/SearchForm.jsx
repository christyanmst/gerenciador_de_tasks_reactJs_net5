import { useState, useEffect } from "react";
import { Button, Card, Input, InputGroup, Row, Col } from "reactstrap";
import { getAll, deleteTag } from "../../services/tagServices";
import Router from "next/router";
import { TableTag } from "../../utils/TableTag";

export default function Home() {
  const [tagList, setTagList] = useState([]);
  const [renderPage, setRenderPage] = useState(false);
  const [filterTitle, setFilterTitle] = useState();

  useEffect(() => {
    if (filterTitle) {
      getAll().then((res) =>
        setTagList(
          res.data.filter((t) =>
            t.title.toLowerCase().includes(filterTitle.toLowerCase())
          )
        )
      );
      setRenderPage(false);
    } else {
      getAll().then((res) => setTagList(res.data));
      setRenderPage(false);
    }
  }, [renderPage]);

  function handleDelete(tag) {
    deleteTag(tag)
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
            <h3>Visualizando Tags</h3>
          </div>
          <Row>
            <Col xs={6}>
              <div className="searchBar">
                <InputGroup>
                  <Input
                    id="title"
                    className="searchInput"
                    placeholder="Título"
                  />
                  <Button
                    className="buttonInput"
                    onClick={() =>
                      searchFilter(document.querySelector("#title").value)
                    }
                  >
                    Pesquisar
                  </Button>
                </InputGroup>
                <Button
                  className="button"
                  onClick={() => Router.push("/tag/create")}
                >
                  Novo
                </Button>
                <Button
                  className="button"
                  onClick={() => Router.push("/dashboard")}
                >
                  Voltar
                </Button>
              </div>
            </Col>
          </Row>

          <TableTag List={tagList} handleDelete={handleDelete} />
        </Card>
      </div>
    </>
  );
}
