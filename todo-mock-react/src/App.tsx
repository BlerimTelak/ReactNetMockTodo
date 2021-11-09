import React from 'react';
import logo from './logo.svg';
import './App.css';
import MainWrapper from './components/MainWrapper/MainWrapper.container';
import MainWrapperContainer from './components/MainWrapper/MainWrapper.container';
import configureStore from "./configureStore";
import {Provider} from "react-redux";
import {initAxios} from "./api";
const initialState = {};
const store = configureStore(initialState);
document.getElementById('app');
initAxios();
function App() {
  return (
      <Provider store={store}>
          <div className="App">
              <MainWrapperContainer />
          </div>
      </Provider>

  );
}

export default App;
