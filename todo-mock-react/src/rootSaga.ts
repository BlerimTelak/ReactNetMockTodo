import {all, fork} from 'redux-saga/effects';
import todos from './components/MainWrapper/saga';

export default function* rootSaga() {
    yield all([
        fork(todos)
    ]);
    // code after fork-effect
}
