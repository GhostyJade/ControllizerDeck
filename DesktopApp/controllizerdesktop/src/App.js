import React, { useEffect } from 'react'

import Settings from './views/settings'
import Home from './views/home'

import AppTabs from './components/apptabs'

import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'

import { useTracked } from './components/DataContainer'
import About from './views/about'
import Welcome from './views/welcome'
import { server_address, server_port } from './utils/net'
import MissingBackend from './views/nobackend'

function App() {
    const [welcome, setWelcome] = React.useState({ error: false, status: false })

    const setWelcomeEnded = () => {
        setWelcome({ ...welcome, status: false })
    }

    useEffect(() => {
        fetch(`http://${server_address}:${server_port}/firstlaunch/`)
            .then(result => result.json())
            .then(response => {
                setWelcome({ error: false, status: response.status })
            }).catch(e => {
                setWelcome({ error: true, status: false })
            })
    }, [])

    const [state, dispatch] = useTracked()
    if (welcome.status)
        return <Welcome end={setWelcomeEnded} />
    if (welcome.error)
        return <MissingBackend />

    return (
        <Router>
            <AppTabs tab={state.tab} change={(e, v) => { dispatch({ type: 'tab', tab: v }) }} />
            <Switch>
                <Route path='/home' component={Home} />
                <Route path='/settings' component={Settings} />
                <Route path='/about' component={About} />
            </Switch>
        </Router>
    )
}

export default App


