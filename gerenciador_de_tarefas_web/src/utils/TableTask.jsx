import { useRouter } from "next/router";
import React from "react";
import { Button, Table } from "reactstrap";

export function TableTask({ List, handleDelete }) {
  const Router = useRouter();

  return (
    <Table hover borderless className="table">
      <thead>
        <tr>
          <th>Id</th>
          <th>Título</th>
          <th>Descrição</th>
          <th>Data de Execução</th>
          <th>Horas de Duração</th>
          <th>Ações</th>
        </tr>
      </thead>
      <tbody>
        
      {List.map((task, index)=> (
        <tr key={index}>
        <th scope="row">
          {task.id}
        </th>
        <td>
          {task.title}
        </td>
        <td>
        {task.description}

        </td>
        <td>
          {task.executionDate}
        </td>
        <td>
          {task.hoursLong}
        </td>
        <td>
          <Button size="sm" className="button-list" title='Remover' onClick={()=> handleDelete(task)}>X</Button>
          <Button size="sm" className="button-list" title='Editar' onClick={()=> Router.push(`/task/update/${task.id}`)}>+</Button>
        </td>
      </tr>
      ))}
      </tbody>
    </Table>
  );
}
