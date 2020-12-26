import React from 'react'
import { AppBar, Tabs, Tab, makeStyles } from '@material-ui/core'
import { Link } from 'react-router-dom'
import { useTranslation } from 'react-i18next'

const useStyles = makeStyles((theme) => ({
    appBar: {
        zIndex: theme.zIndex.drawer + 1,
        backgroundColor: '#a800ff'
    }
}))

export default function AppTabs(props) {
    const classes = useStyles()
    const { t } = useTranslation();

    return (
        <AppBar className={classes.appBar} position="sticky">
            <Tabs centered onChange={props.change} value={props.tab}>
                <Tab label={t('TAB_CONFIG')} component={Link} to="/home" />
                <Tab label={t('TAB_SETTINGS')} component={Link} to="/settings" />
                <Tab label={t('TAB_ABOUT')} component={Link} to="/about" />
            </Tabs>
        </AppBar>
    )
}