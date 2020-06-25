import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import * as serviceWorker from './serviceWorker';

import { Provider, reducer, initialState } from './components/DataContainer';

ReactDOM.render(
  <React.StrictMode>
    <Provider reducer={reducer} initialState={initialState}>
      <App />
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);

serviceWorker.unregister();
