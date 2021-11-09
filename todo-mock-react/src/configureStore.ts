/**
 * Create the store with dynamic reducers
 */

import {createStore, applyMiddleware, compose} from 'redux';
import createSagaMiddleware from 'redux-saga';
import rootSaga from './rootSaga';
import rootReducer from './reducers';


export default function configureStore(initialState = {}) {
    let composeEnhancers = compose;

    const sagaMiddleware = createSagaMiddleware();

    // Create the store with two middlewares
    // 1. sagaMiddleware: Makes redux-sagas work
    // 2. routerMiddleware: Syncs the location/URL path to the state
    const middlewares = [sagaMiddleware];

    const enhancers = [applyMiddleware(...middlewares)];


    const store = createStore(
        rootReducer,
        { ...initialState },
        composeEnhancers(...enhancers),
    );
    sagaMiddleware.run(rootSaga);

    return store;
}
