import React from "react";
import './listLab.css'
import Button from 'react-bootstrap/Button';

function ListLab() {
    return ( 
    <div style = {{margin: '0 50px'}}>
        <h3>Лабораторные работы группы</h3>
        <div className="container">

        </div>
        <Button style = {{borderRadius: '0', borderBottomLeftRadius: '10px'}}>Добавить</Button>
        <Button style = {{borderRadius: '0', borderBottomRightRadius: '10px'}}>Удалить</Button>

        <h3>Расписание группы</h3>
        <div className="container">

        </div>
        <Button style = {{borderRadius: '0', borderBottomLeftRadius: '10px'}}>Добавить</Button>
        <Button style = {{borderRadius: '0'}}>Изменить</Button>
        <Button style = {{borderRadius: '0', borderBottomRightRadius: '10px'}}>Удалить</Button>
    </div> 
    );
}

export default ListLab;