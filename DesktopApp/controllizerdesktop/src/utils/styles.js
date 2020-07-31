import { makeStyles } from '@material-ui/core'
const drawerWidth = 230

const ConfigurationBarStyles = makeStyles((theme) => ({
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

export {
    ConfigurationBarStyles
}