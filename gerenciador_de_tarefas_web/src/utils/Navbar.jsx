import React from "react";
import { Navbar, NavbarBrand, Nav, NavItem, NavLink } from "reactstrap";
import Router from "next/router";

function Example(args) {
  return (
    <div>
      <Navbar className="navbar" dark>
        <NavbarBrand className="navbar-brand" onClick={() => Router.push("/")}>
          Gerenciar Tasks
        </NavbarBrand>
        <Nav className="nav">
          <NavItem>
            <NavLink className={"item"} onClick={() => Router.push("/task")}>
              Tasks
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink className={"item"} onClick={() => Router.push("/tag")}>
              Tags
            </NavLink>
          </NavItem>
        </Nav>
      </Navbar>
    </div>
  );
}

export default Example;
