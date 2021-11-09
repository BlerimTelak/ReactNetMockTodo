import { Todo } from '../../models/Todo.interface';
import {
    LIST_TODOS,
    CREATE_TODO,
    DELETE_TODO,
    TOGGLE_FINISHED_TODO,
    LIST_TODOS_SUCCESS,
    LIST_TODOS_ERROR,
    CREATE_TODO_SUCCESS,
    CREATE_TODO_ERROR,
    DELETE_TODO_SUCCESS,
    DELETE_TODO_ERROR,
    TOGGLE_FINISHED_TODO_SUCCESS, TOGGLE_FINISHED_TODO_ERROR
} from './constants';

export const createTodo = (todoString: string) => ({
    type: CREATE_TODO,
    payload: { todoString }
});

export const createTodoSuccess = (todoList: any) => ({
    type: CREATE_TODO_SUCCESS,
    payload: {
        todoList: todoList
    }
});

export const createTodoError = (todo: Todo) => ({
    type: CREATE_TODO_ERROR,
    payload: todo
});

export const deleteTodo = (id: number) => ({
    type: DELETE_TODO,
    payload: {
        id: id
    }
});

export const deleteTodoSuccess = (todoList: any) => ({
    type: DELETE_TODO_SUCCESS,
    payload: {
        todoList: todoList
    }
});

export const deleteTodoError = () => ({
    type: DELETE_TODO_ERROR,
});

export const toggleFinishedTodo = (id: number) => ({
    type: TOGGLE_FINISHED_TODO,
    payload: {
        id: id
    }
});

export const toggleFinishedTodoSuccess = (todoList: any) => ({
    type: TOGGLE_FINISHED_TODO_SUCCESS,
    payload: {
        todoList: todoList
    }
});

export const toggleFinishedTodoError = () => ({
    type: TOGGLE_FINISHED_TODO_ERROR,
});

export const listTodos = () => ({
    type: LIST_TODOS
});

export const listTodosSuccess = (todoList: any) => ({
    type: LIST_TODOS_SUCCESS,
    payload: {
        todoList: todoList
    }
});

export const listTodosError = () => ({
    type: LIST_TODOS_ERROR,
});