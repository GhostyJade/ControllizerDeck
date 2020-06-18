import React, {Component} from 'react'

import { BrowserRouter as Router, Route } from 'react-router-dom'
import Settings from './settings'
import Home from './home'

export default class ViewManager extends Component {
    static Views() {
        return {
            settings: <Settings />,
            home: <Home />
        }
    }
    static View(props) {
        let name = props.location.search.substr(1);
        console.log(name)
        let view = ViewManager.Views()[name];
        if (view == null)
            throw new Error("View '" + name + "' is undefined");
        return view;
    }

    render() {
        return (
            <Router>
                <div>
                    <Route path='/' component={ViewManager.View} />
                </div>
            </Router>
        );
    }
}