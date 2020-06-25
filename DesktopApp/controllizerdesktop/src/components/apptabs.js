import React from 'react'
import { AppBar, Tabs, Tab, makeStyles } from '@material-ui/core'
import { Link } from 'react-router-dom'

const useStyles = makeStyles((theme) => ({

}))

export default function AppTabs(props) {
    const classes = useStyles()

    return (
        <AppBar position="static">
            <Tabs centered onChange={props.change} value={props.tab}>
            <Tab label="Configuration" component={Link} to="/home" />
                <Tab label="Settings" component={Link} to="/settings" />
                <Tab label="About" />
            </Tabs>
        </AppBar>
    )
}