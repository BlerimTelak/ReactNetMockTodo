import React from "react";
import TodoInput from "../TodoInput/TodoInput";
import '../TodoInput/style.css';
import TodoList from "../TodoList/TodoList";


const MainWrapperContainer: React.FC = () => {
    return(
        <div>
            <h1>Todo PA</h1>
            <TodoInput />
            <TodoList />
        </div>
    )
}

export default MainWrapperContainer;