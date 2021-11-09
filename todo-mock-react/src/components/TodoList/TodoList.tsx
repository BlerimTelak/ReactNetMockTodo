import React, {useCallback, useEffect, useState} from "react";
import {useDispatch, useSelector} from 'react-redux';
import {listTodos} from "../MainWrapper/actions";
import { Todo } from "../../models/Todo.interface";
import {RootReducer} from "../../reducers";
import TodoListItem from "../TodoListItem/TodoListItem";

const TodoList: React.FC = () => {
    const todoList: Todo[] = useSelector((state: RootReducer) => state.todo.todoList)

    const dispatch = useDispatch();
    const listAllTodos = useCallback(() => dispatch(listTodos()), [dispatch]);

    useEffect(() => {
        listAllTodos();
    }, []);


    return (
        <div>
            <ul>
                {todoList && todoList.map((todo) =>
                    <TodoListItem key={todo.id} todo={todo}/>
                )}
            </ul>
        </div>
    )
}

export default TodoList;