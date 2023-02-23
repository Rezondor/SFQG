import React from "react";
import ListLab from "../list-lab/listLab";
import './navbar.css'
import logo from './utmn.png'


function Navbar() {
    return ( 
        <div>
            <nav className="navbar navbar-expand-lg fixed-top">

            <div className="collapse navbar-collapse" id="navbarCollapse">
                <ul style={{borderRight: '1px solid rgba(0, 0, 0, 0.55)'}} className="navbar-nav mr-auto sidenav" id="navAccordion">
                <li className="nav-item">
                    <a className="nav-link" href="#top"><img style={{width: '70px', height: '70px'}} src={logo} alt="" /></a>
                </li>
                <li className="nav-item">
                    <a className="nav-link" href="#top">Группы</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link" href="#top">Статистика</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link" href="#top">История</a>
                </li>
                <li className="nav-item">
                    <a className="nav-link" href="/rooms">Комнаты</a>
                </li>
                </ul>
            </div>
            </nav>

            <main className="content-wrapper">
            <div className="container-fluid">
                <ListLab />
            </div>
            </main>
        </div>
     );
}

export default Navbar;