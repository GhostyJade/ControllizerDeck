import React, { useEffect } from 'react'
import { Drawer, Toolbar, Button, Select, FormControl, InputLabel, MenuItem, InputAdornment, IconButton, Input, TextField } from '@material-ui/core'
import { useTracked } from './DataContainer'

import { Add as AddIcon } from '@material-ui/icons'

import { ConfigurationBarStyles } from '../utils/styles'
import { server_address, server_port } from '../utils/net'

const ParametersComponent = ({ itemData, setItemData, state }) => {
    const id = itemData.action
    if (id === 1)
        return <FileChooser state={state} itemData={itemData} setItemData={setItemData} />
    if (id === 2)
        return <WebsitePicker state={state} itemData={itemData} setItemData={setItemData} />
    return null
}

const WebsitePicker = (props) => {
    const styles = ConfigurationBarStyles()
    return (
        <div>
            <FormControl>
                <TextField
                    id="websiteName"
                    type="text"
                    className={styles.actionTypeBox}
                    value={props.itemData.name}
                    onChange={e => props.setItemData({ ...props.itemData, name: e.target.value })}
                    label="Website Name"
                />
            </FormControl>
            <FormControl>
                <TextField
                    id="websiteUri"
                    type="text"
                    className={styles.actionTypeBox}
                    value={props.itemData.websiteUri}
                    onChange={e => props.setItemData({ ...props.itemData, websiteUri: e.target.value })}
                    label="Website URL"
                />
            </FormControl>
        </div>
    )
}

const DataComponent = (props) => {
    const styles = ConfigurationBarStyles()
    const { state, itemData, setItemData } = props

    if (!state.selectedItem) {
        return null
    }

    return (
        <div>
            <FormControl className={styles.actionTypeBox}>
                <InputLabel id="actionType">Action Type</InputLabel>
                <Select value={itemData.action} onChange={(e) => setItemData({ ...itemData, action: e.target.value })} labelId="actionType">
                    <MenuItem value={0}>None</MenuItem>
                    <MenuItem value={1}>Launch Program</MenuItem>
                    <MenuItem value={2}>Open Website</MenuItem>
                </Select>
            </FormControl>
            <ParametersComponent state={state} itemData={itemData} setItemData={setItemData} />
        </div>
    )
}

const FileChooser = (props) => {
    const styles = ConfigurationBarStyles()

    const ShowFilePicker = () => {
        const dialogResult = window.dialog.showOpenDialogSync({ properties: ['openFile'] })
        if (dialogResult) //It's length is 1 if the user has selected an app. It contains the app path at index 0
            props.setItemData({ ...props.itemData, path: dialogResult[0] })
    }

    return (
        <div>
            <FormControl>
                <TextField
                    id="actionName"
                    type="text"
                    className={styles.actionTypeBox}
                    value={props.itemData.name}
                    onChange={e => props.setItemData({ ...props.itemData, name: e.target.value })}
                    label="Action name"
                />
            </FormControl>
            <FormControl className={styles.executableBox}>
                <InputLabel htmlFor="file">Executable location</InputLabel>
                <Input
                    id="file"
                    type="text"
                    value={props.itemData.path}
                    onChange={e => props.setItemData({ ...props.itemData, path: e.target.value })}
                    endAdornment={
                        <InputAdornment position="end">
                            <IconButton className={styles.iconContainer}
                                aria-label="pick app file"
                                onClick={ShowFilePicker}
                            >
                                <AddIcon className={styles.addIcon} />
                            </IconButton>
                        </InputAdornment>
                    }
                />
            </FormControl>
        </div>
    )
}


export default function ConfigurationBar(props) {
    const [state,] = useTracked()
    const styles = ConfigurationBarStyles()

    const [itemData, setItemData] = React.useState({ action: 0, name: '', path: '', websiteUri: '' })

    useEffect(() => {
        if (state.selectedItem != null)
            if (state.selectedItem.AssociatedAction !== null) {
                if (state.selectedItem.AssociatedAction.Type === 1) { //action 1 = launch program           
                    setItemData({ action: state.selectedItem.AssociatedAction.Type, name: state.selectedItem.AssociatedAction.AppName, path: state.selectedItem.AssociatedAction.FullAppDirectory })
                } else if (state.selectedItem.AssociatedAction.Type === 2) { //action 2 = open website
                    setItemData({ action: state.selectedItem.AssociatedAction.Type, name: state.selectedItem.AssociatedAction.WebsiteName, websiteUri: state.selectedItem.AssociatedAction.WebsiteUri })
                }
            } else {
                setItemData({ action: 0, name: '', path: '', websiteUri: '' })
            }

    }, [state.selectedItem])

    const sendData = () => {
        //if (itemData.action === 0 || itemData.name === '' || itemData.path === '') return;// TODO check path if action number is 1, allow 0 to be action reset
        //TODO add checks
        fetch(`http://${server_address}:${server_port}/hardware/functions/`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ id: state.selectedItem.Identifier, data: itemData })
        }).then(response => response.json()).then(e => console.log(e))
    }

    return (
        <Drawer classes={{ paper: styles.drawerPaper }} className={styles.drawer} variant="permanent" anchor="right">
            <Toolbar />
            <DataComponent state={state} itemData={itemData} setItemData={setItemData} />
            <Button className={styles.saveButton} size="small" variant="contained" onClick={sendData}>Save</Button>
        </Drawer>
    )
}