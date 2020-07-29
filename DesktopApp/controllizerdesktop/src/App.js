import React from 'react'

import Settings from './views/settings'
import Home from './views/home'

import AppTabs from './components/apptabs'

import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'

import { useTracked } from './components/DataContainer'
import About from './views/about'

function App() {
  const [state, dispatch] = useTracked()

  return (
    <Router>
      <AppTabs tab={state.tab} change={(e, v) => { dispatch({ type: 'tab', tab: v }) }} />
      <Switch>
        <Route path='/home' component={Home} />
        <Route path='/settings' component={Settings} />
        <Route path='/about' component={About}/>
      </Switch>
    </Router>
  )
}

export default App


