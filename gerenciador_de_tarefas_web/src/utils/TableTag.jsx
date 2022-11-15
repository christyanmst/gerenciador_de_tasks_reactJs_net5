import { useRouter } from 'next/router';
import React from "react";
import { Button, Table } from "reactstrap";

export function TableTag({ List, handleDelete }) {
  const Router = useRouter();

  return (
    <Table hover borderless className="table">
      <thead>
        <tr>
          <th>Id</th>
          <th>Título</th>
          <th>Descrição</th>
          <th>Ações</th>
        </tr>
      </thead>
      <tbody>
        
      {List.map((tag, index)=> (
        <tr key={index}>
        <th scope="row">
          {tag.id}
        </th>
        <td>
          {tag.title}
        </td>
        <td>
        {tag.description}

        </td>
        <td>
          <Button size="sm" className="button-list" title='Remover' onClick={()=> handleDelete(tag)}>X</Button>
          <Button size="sm" className="button-list" title='Editar' onClick={()=> Router.push(`/tag/update/${tag.id}`)}>+</Button>
        </td>
      </tr>
      ))}
      </tbody>
    </Table>
  );
}
