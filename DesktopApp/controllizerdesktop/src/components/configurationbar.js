import React from 'react'
import { Drawer, Toolbar, Button, makeStyles, Typography, ThemeProvider, TextField, Select, FormControl, InputLabel, MenuItem, InputAdornment, IconButton, Input, Icon } from '@material-ui/core'
import { useTracked } from './DataContainer'

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
    }
}))

export default function ConfigurationBar(props) {
    const styles = useStyle()
    const [state, dispatch] = useTracked()

    const [itemData, setItemData] = React.useState({ action: 0, path: '' })

    const FileChooser = () => {
        return (
            <div>
                <FormControl>
                    <InputLabel htmlFor="file">Executable location</InputLabel>
                    <Input
                        id="file"
                        type="text"
                        value={itemData.path}
                        endAdornment={
                            <InputAdornment position="end">
                                <IconButton
                                    aria-label="pick app file"
                                    onClick={() => (setItemData({ ...itemData, path: window.dialog.showOpenDialogSync({ properties: ['openFile'] })[0] }))}
                                >
                                    ...
                                </IconButton>
                            </InputAdornment>
                        }
                    />
                </FormControl>
            </div>
        )
    }

    const DataComponent = () => {
        if (!state.selectedItem) return null
        return (
            <div>
                <FormControl>
                    <InputLabel id="actionType">Action Type</InputLabel>
                    <Select value={itemData.action} onChange={(e) => setItemData({ ...itemData, action: e.target.value })} labelId="actionType">
                        <MenuItem value={0}>None</MenuItem>
                        <MenuItem value={1}>Launch Program</MenuItem>
                    </Select>
                </FormControl>
                {itemData.action === 1 ? <FileChooser /> : null}
            </div>
        )
    }

    return (
        <Drawer classes={{ paper: styles.drawerPaper }} className={styles.drawer} variant="permanent" anchor="right">
            <Toolbar />
            <DataComponent />
            <Button className={styles.saveButton} size="small" variant="contained">Save</Button>
        </Drawer>
    )
}