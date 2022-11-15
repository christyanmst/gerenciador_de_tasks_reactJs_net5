import { useState, useEffect } from "react";
import {
  Button,
  Form,
  FormGroup,
  Input,
  Label,
  Card,
  Row,
  Col,
} from "reactstrap";
import { save } from "../../services/taskServices";
import Router from "next/router";
import { getAll } from "../../services/tagServices";
import { getById as getTask } from "../../services/taskServices";

import Select from "react-select";

export default function DetailForm({ taskId }) {
  const [task, setTask] = useState({});
  const [tagList, setTagList] = useState([]);
  const [defaultTags, setDefaultTags] = useState([]);

  function handleSave(e) {
    e.preventDefault();
    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);
    !taskId ? (data.id = -Date.now()) : null;
    data.selectedTagList = defaultTags;
    save(data)
      .then(() => Router.push("/task"))
      .catch((err) => console.log(err));
  }

  const setHandle = (e) => {
    setDefaultTags(e);
  };

  useEffect(() => {
    getAll().then((res) => {
      setTagList(res.data);
      if (taskId) {
        getTask(taskId)
          .then((x) => {
            setTask(x.data);
            selectedTags(res.data, x.data.selectedTagList);
          })
          .catch((err) => console.log(err));
      }
    });
  }, []);

  function selectedTags(tagList, selectedTagList) {
    setDefaultTags(
      selectedTagList.map((x) =>
        tagList.filter((i) => i.id == x.tagId).reduce((x) => x)
      )
    );
  }

  const tags = tagList.map((r, i) => {
    r.label = r.title;
    r.value = i + 1;
    return r;
  });

  return (
    <>
      <div className="container">
        <Card className="cardInput">
          <div className="title">
            <h3>{taskId ? "Editando Task" : "Cadastrando Task"}</h3>
          </div>
          <Form onSubmit={handleSave}>
            <Row>
              <Col xs={2}>
                <FormGroup>
                  <Label form="id">Id</Label>
                  <Input
                    className="inputs"
                    name={"id"}
                    value={taskId ? taskId : "NOVO"}
                    readOnly
                  />
                </FormGroup>
              </Col>
              <Col xs={10}>
                <FormGroup>
                  <Label form="title">Título</Label>
                  <Input
                    className="inputs"
                    name="title"
                    type="text"
                    defaultValue={taskId ? task?.title : ""}
                    maxLength={100}
                    required
                  />
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col xs={12}>
                <FormGroup>
                  <Label form="description">Descrição</Label>
                  <Input
                    className="inputs"
                    name="description"
                    type="textarea"
                    defaultValue={taskId ? task?.description : ""}
                    maxLength={255}
                    required
                  />
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col xs={6}>
                <FormGroup>
                  <Label form="executionDate">Data da Execução</Label>
                  <Input
                    className="inputs"
                    name="executionDate"
                    type="datetime-local"
                    defaultValue={taskId ? task?.executionDate : ""}
                    required
                  />
                </FormGroup>
              </Col>
              <Col xs={6}>
                <FormGroup>
                  <Label form="hoursLong">Tempo de Duração (H)</Label>
                  <Input
                    className="inputs"
                    name="hoursLong"
                    type="number"
                    defaultValue={taskId ? task?.hoursLong : ""}
                    required
                  />
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col xs={6}>
                <FormGroup>
                  <Label>Tags</Label>
                  <Select
                    id="long-value-select"
                    instanceId="long-value-select"
                    options={tags}
                    value={defaultTags}
                    onChange={setHandle}
                    isMulti
                    className={"select"}
                  />
                </FormGroup>
              </Col>
            </Row>
            <Button type="submit" className="buttonInput">
              {taskId ? "Salvar" : "Enviar"}
            </Button>
            <Button
              onClick={() => Router.push("/task")}
              className="buttonInput"
            >
              Voltar
            </Button>
          </Form>
        </Card>
      </div>
    </>
  );
}
