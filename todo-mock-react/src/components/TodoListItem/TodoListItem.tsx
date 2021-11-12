import React, {useCallback} from "react";
import {ReactComponent as DeleteIcon} from "../../assets/icons/deleteIcon.svg";
import { ReactComponent as Checkmark } from '../../assets/icons/done.svg';
import './styles.css'
import {Todo} from "../../models/Todo.interface"
import {useDispatch} from "react-redux";
import {createTodo, deleteTodo, toggleFinishedTodo} from "../MainWrapper/actions";
const TodoListItem: React.FC<any> = props => {
    const isChecked = props.todo.isFinished ? 'checked' : ''
    const isDone = isChecked ? 'done-Item' : ''
    const dispatch = useDispatch();
    const toggleTodoItem = useCallback((id: number) => dispatch(toggleFinishedTodo(id)), [dispatch]);
    const deleteTodoItem = useCallback((id: number) => dispatch(deleteTodo(id)), [dispatch]);

    function checkmarkClickHandler(){
        toggleTodoItem(props.todo.id);
    }

    function deleteClickHandler(){
        deleteTodoItem(props.todo.id);
        console.log(props.todo.id);
    }
    return (
        <div>
            <li key={props.key} className={`todoItem--container ${isDone}`}>
                <div className="d-flex">
                    <label className='checkbox--container'>
                        <Checkmark className={`checkmark ${isChecked}`} onClick={checkmarkClickHandler}/>
                    </label>
                    <span className={isDone}>{props.todo.text}</span>
                    <DeleteIcon className="delete--button" onClick={deleteClickHandler}></DeleteIcon>

                </div>
            </li>
        </div>
    )
}
export default TodoListItem;