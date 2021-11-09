/**
 * Combine all reducers in this file and export the combined reducers.
 */

import {combineReducers} from 'redux';
import todoReducer from "./components/MainWrapper/reducer";
import { DefaultRootState } from 'react-redux';
export interface RootReducer extends DefaultRootState {
    todo: any
}
/**
 * Merges the main reducer with the router state and dynamically injected reducers
 */
const combinedReducers = combineReducers({
    todo: todoReducer,
});

const rootReducer = (state: any, action: any) => {
    return combinedReducers(state, action);
};

export default rootReducer;