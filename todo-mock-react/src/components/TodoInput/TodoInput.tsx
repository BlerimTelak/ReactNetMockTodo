import React, {useCallback, useState} from "react";
import {useDispatch, useSelector} from 'react-redux';
import './style.css'
import { createTodo } from "../MainWrapper/actions";

const TodoInput: React.FC<any> = props => {
    const [addTodoInputBoxValue, setAddTodoInputBoxValue] = useState("");
    const dispatch = useDispatch();
    const createTodoItem = useCallback((addTodoInputBoxValue: string) => dispatch(createTodo(addTodoInputBoxValue)), [dispatch]);

    function clickHandler(){
        createTodoItem(addTodoInputBoxValue);
        setAddTodoInputBoxValue("");
    }

    function handleTextInputChange(source: any)
    {
        setAddTodoInputBoxValue(source.target.value)
    }

    return(
        <div>
            <input type={"text"} value={addTodoInputBoxValue} onChange={handleTextInputChange}/>
            <button onClick={() => clickHandler()}>Add</button>
        </div>
    )
}

export default TodoInput;