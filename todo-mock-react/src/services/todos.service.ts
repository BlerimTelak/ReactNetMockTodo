import axios from 'axios';

export const getListOfTodos = async () =>{
    return await axios.get('https://localhost:44328/api/Todo/GetAll');
}

export const createTodo = async (text: string) => {
    return await axios.post(`https://localhost:44328/api/Todo/Create`, {text});
};

export const toggleFinishedTodo = async (id: number) => {
    return await axios.post(`https://localhost:44328/api/Todo/Toggle?id=${id}`);
};

export const deleteTodo = async (id: number) => {
    return await axios.post(`https://localhost:44328/api/Todo/Delete?id=${id}`);
};