import {takeEvery, call, put, takeLatest} from 'redux-saga/effects';
import {
    listTodosError, listTodosSuccess,
    createTodoSuccess, createTodoError,
    toggleFinishedTodoSuccess, toggleFinishedTodoError,
    deleteTodoSuccess, deleteTodoError
} from "./actions";
import {CREATE_TODO, DELETE_TODO, LIST_TODOS, TOGGLE_FINISHED_TODO} from "./constants";
import * as service from "../../services/todos.service";


function* listTodos() {
    try {
        const response = yield call(service.getListOfTodos);
        yield put(listTodosSuccess(response.data));
    } catch (e) {
        yield put(listTodosError());
    }
}

function* createTodo(action: any){
    try{
        const response = yield call(service.createTodo, action.payload.todoString);
        yield put(createTodoSuccess(response.data));
    } catch (e) {
        yield put(createTodoError(e));
    }
}

function* toggleFinishedTodo(action: any){
    try{
        const response = yield call(service.toggleFinishedTodo, action.payload.id);
        yield put(toggleFinishedTodoSuccess(response.data));
    } catch (e) {
        yield put(toggleFinishedTodoError());
    }
}

function* deleteTodo(action: any){
    try{
        const response = yield call(service.deleteTodo, action.payload.id);
        yield put(deleteTodoSuccess(response.data));
    } catch (e) {
        yield put(deleteTodoError());
    }
}

export default function* todos() {
    yield takeLatest(LIST_TODOS, listTodos);
    yield takeEvery(CREATE_TODO, createTodo);
    yield takeLatest(DELETE_TODO, deleteTodo);
    yield takeLatest(TOGGLE_FINISHED_TODO, toggleFinishedTodo);
}
