import React, { useEffect } from 'react'
import { Drawer, makeStyles, Button, Toolbar } from '@material-ui/core'

const drawerWidth = 200

const useStyle = makeStyles((theme) => ({
    drawerPaper: {
        width: drawerWidth
    },
    drawer: {
        width: drawerWidth,
        flexShrink: 0
    },
    saveButton: {
        backgroundColor: '#a800ff',
        color: '#fff',
        position: 'absolute',
        width: 90,
        alignSelf: 'center',
        bottom: 12
    }
}))


export default function Home(props) {

    const styles = useStyle()

    useEffect(() => {
        fetch('http://localhost:8080/hardware/').then(data => data.json()).then(e => console.log(e))
    }, [])

    return (
        <Drawer classes={{ paper: styles.drawerPaper }} className={styles.drawer} variant="permanent" anchor="right">
            <Toolbar />
            <Button className={styles.saveButton} size="small" variant="contained">Save</Button>
        </Drawer>
    )
}