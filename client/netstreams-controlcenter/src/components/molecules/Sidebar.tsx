import React, { FC } from "react";
import { Nav } from "react-bootstrap";
import { withRouter, RouteComponentProps } from "react-router";

export type Link = {
    ref: string,
    name:string,
}

type PathParamsType = {
  param1: string,
}

type SidebarProps =  RouteComponentProps<PathParamsType>  & {
    navigationLinks: Array<Link>
}

const Side: FC<SidebarProps> = ({navigationLinks}: SidebarProps) => {
  return (
    <>
      <Nav
        className="col-md-12 d-none d-md-block bg-light sidebar"
        activeKey="/home"
        onSelect={(selectedKey) => alert(`selected ${selectedKey}`)}
      >
        <div className="sidebar-sticky"></div>

        { 
            navigationLinks.map((link, i) => {
                return (  
                    <Nav.Item>
                        <Nav.Link href={link.ref}>{link.name}</Nav.Link>
                    </Nav.Item>
                )
            })
        }
      </Nav>
    </>
  );
};


const Sidebar = withRouter(Side);
export default Sidebar;