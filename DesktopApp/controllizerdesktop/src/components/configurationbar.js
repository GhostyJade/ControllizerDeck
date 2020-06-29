import React, { useEffect } from 'react'
import { Drawer, Toolbar, Button, makeStyles, Select, FormControl, InputLabel, MenuItem, InputAdornment, IconButton, Input, TextField } from '@material-ui/core'
import { useTracked } from './DataContainer'

import { Add as AddIcon } from '@material-ui/icons'

const drawerWidth = 230

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
    },
    actionTypeBox: {
        width: 190,
        left: 20,
        right: 20
    },
    executableBox: {
        width: 190,
        left: 20,
        right: 20
    },
    iconContainer: {
        padding: 4
    },
    addIcon: {
        color: '#000',
        fontSize: 18,
    }
}))

const DataComponent = (props) => {
    const { state, styles, itemData, setItemData } = props
    if (!state.selectedItem)
        return null
    return (
        <div>
            <FormControl className={styles.actionTypeBox}>
                <InputLabel id="actionType">Action Type</InputLabel>
                <Select value={itemData.action} onChange={(e) => setItemData({ ...itemData, action: e.target.value })} labelId="actionType">
                    <MenuItem value={0}>None</MenuItem>
                    <MenuItem value={1}>Launch Program</MenuItem>
                </Select>
            </FormControl>
            {itemData.action === 1 ? <FileChooser state={state} styles={styles} itemData={itemData} setItemData={setItemData} /> : null}
        </div>
    )
}

const FileChooser = (props) => {
    return (
        <div>
            <FormControl>
                <TextField
                    id="actionName"
                    type="text"
                    value={props.itemData.name}
                    onChange={e => props.setItemData({ ...props.itemData, name: e.target.value })}
                    label="Action name"
                />
            </FormControl>
            <FormControl className={props.styles.executableBox}>
                <InputLabel htmlFor="file">Executable location</InputLabel>
                <Input
                    id="file"
                    type="text"
                    value={props.itemData.path}
                    onChange={e => props.setItemData({ ...props.itemData, path: e.target.value })}
                    endAdornment={
                        <InputAdornment position="end">
                            <IconButton className={props.styles.iconContainer}
                                aria-label="pick app file"
                                onClick={() => (props.setItemData({ ...props.itemData, path: window.dialog.showOpenDialogSync({ properties: ['openFile'] })[0] }))}
                            >
                                <AddIcon className={props.styles.addIcon} />
                            </IconButton>
                        </InputAdornment>
                    }
                />
            </FormControl>
        </div>
    )
}


export default function ConfigurationBar(props) {
    const styles = useStyle()
    const [state, dispatch] = useTracked()

    const [itemData, setItemData] = React.useState({ action: 0, name: '', path: '' })

    useEffect(() => {
        setItemData({ action: 0, name: '', path: '' })
    }, [state.selectedItem])

    const sendData = () => {
        if (itemData.action === 0 || itemData.name === '') return;//check path if action number is 1
            fetch('http://localhost:8080/hardware/functions/', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: itemData
            }).then(response => response.json()).then(e => console.log(e))
    }

    return (
        <Drawer classes={{ paper: styles.drawerPaper }} className={styles.drawer} variant="permanent" anchor="right">
            <Toolbar />
            <DataComponent state={state} styles={styles} itemData={itemData} setItemData={setItemData} />
            <Button className={styles.saveButton} size="small" variant="contained" onClick={sendData}>Save</Button>
        </Drawer>
    )
}