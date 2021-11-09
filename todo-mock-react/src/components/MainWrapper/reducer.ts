import {
    LIST_TODOS,
    CREATE_TODO,
    TOGGLE_FINISHED_TODO,
    DELETE_TODO,
    LIST_TODOS_SUCCESS,
    TOGGLE_FINISHED_TODO_SUCCESS,
    TOGGLE_FINISHED_TODO_ERROR,
    DELETE_TODO_SUCCESS,
    DELETE_TODO_ERROR,
    LIST_TODOS_ERROR,
    CREATE_TODO_SUCCESS, CREATE_TODO_ERROR
} from './constants';
import produce from 'immer'
import {Todo} from '../../models/Todo.interface'

export const initialState = {
    todoList: [],
    loading: false
}

export const todoReducer = (state = initialState, action: any) =>
    produce(state, draft => {
        switch (action.type) {
            case LIST_TODOS:
                draft.loading = true;
                break;
            case LIST_TODOS_SUCCESS:
                draft.loading = false
                draft.todoList = action.payload.todoList
                break;
            case LIST_TODOS_ERROR:
                draft.loading = false;
                break;

            case CREATE_TODO:
                draft.loading = true;
                break;
            case CREATE_TODO_SUCCESS:
                draft.loading = false
                draft.todoList = action.payload.todoList
                break;
            case CREATE_TODO_ERROR:
                draft.loading = false
                break;

            case TOGGLE_FINISHED_TODO:
                draft.loading = true;
                break;
            case TOGGLE_FINISHED_TODO_SUCCESS:
                draft.loading = false
                draft.todoList = action.payload.todoList
                break;
            case TOGGLE_FINISHED_TODO_ERROR:
                draft.loading = false
                break;

            case DELETE_TODO:
                draft.loading = true;
                break;
            case DELETE_TODO_SUCCESS:
                draft.loading = false
                draft.todoList = action.payload.todoList
                break;
            case DELETE_TODO_ERROR:
                draft.loading = false
                break;

            default:
                break;
        }
    });

export default todoReducer;