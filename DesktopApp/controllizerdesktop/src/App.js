import React, { useEffect } from 'react'

import Settings from './views/settings'
import Home from './views/home'

import AppTabs from './components/apptabs'

import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'

import { useTracked } from './components/DataContainer'
import About from './views/about'
import Welcome from './views/welcome'

function App() {
    const [welcome, setWelcome] = React.useState({ error: false, status: false })

    useEffect(() => {
        const fetchWelcomeData = async () => {
            await fetch("http://localhost:8080/firstlaunch/")
                .then(result => result.json())
                .then(response => {
                    if (response.status)
                        setWelcome({ error: false, status: true })
                })
                .catch(e => {
                    setWelcome({ error: true, status: false })
                })
        }
        fetchWelcomeData()
    }, [])

    const [state, dispatch] = useTracked()

    if (!welcome.status)
        return <Welcome />

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


