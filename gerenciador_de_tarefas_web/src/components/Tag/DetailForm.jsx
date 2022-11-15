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
import { save, getById } from "../../services/tagServices";
import Router from "next/router";

export default function DetailForm({ tagId }) {
  const [tag, setTag] = useState({});

  useEffect(() => {
    if (tagId) {
      getById(tagId)
        .then((res) => setTag(res.data))
        .catch((err) => console.log(err));
    }
  }, []);

  function handleSave(e) {
    e.preventDefault();
    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);
    !tagId ? (data.id = -Date.now()) : null;
    save(data)
      .then(() => Router.push("/tag"))
      .catch((err) => console.log(err));
  }

  return (
    <>
      <div className="container">
        <Card className="cardInput">
          <div className="title">
            <h3>{tagId ? "Editando Tag" : "Cadastrando Tag"}</h3>
          </div>
          <Form onSubmit={handleSave}>
            <Row>
              <Col xs={2}>
                <FormGroup>
                  <Label form="id">Id</Label>
                  <Input
                    className="inputs"
                    name={"id"}
                    value={tagId ? tagId : "NOVO"}
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
                    defaultValue={tagId ? tag.title : ""}
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
                    defaultValue={tagId ? tag.description : ""}
                    maxLength={255}
                    required
                  />
                </FormGroup>
              </Col>
            </Row>
            <Button type="submit" className="buttonInput">
            {tagId ? "Salvar" : "Enviar"}

            </Button>
            <Button onClick={() => Router.push("/tag")} className="buttonInput">
              Voltar
            </Button>
          </Form>
        </Card>
      </div>
    </>
  );
}
