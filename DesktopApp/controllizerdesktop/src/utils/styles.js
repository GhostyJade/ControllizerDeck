import { makeStyles, createMuiTheme } from '@material-ui/core'

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

const HardwareDrawerStyles = {
    container: {
        marginTop: 34,
        marginLeft: 34,
    }
}

const WelcomeScreenStylesOne = makeStyles(theme => ({
    pageOneContainer: {
        backgroundColor: '#303030',
        textAlign: 'center',
        height: '100%'
    },
    pageOneTitleText: {
        fontSize: 24,
        color: 'white'
    },
    infoContainer: {
        paddingTop: 36
    },
    pageOneText: {
        color: '#acacac'
    },
    btnNext: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        right: 12,
        float: "right"
    },
    btnNextContainer: {
        width: '100%',
        position: 'absolute',
        bottom: 12
    }
}))

const WelcomeScreenStylesTwo = makeStyles(theme => ({
    titleText: {
        paddingTop: 32,
        paddingBottom: 32,
        color: 'white',
        fontSize: 20
    },
    pageTwoContainer: {
        backgroundColor: '#303030',
        textAlign: 'center',
        height: '100%'
    },
    text: {
        color: 'white'
    },
    btnPrev: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        left: 12,
        float: "left"
    },
    btnNext: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        right: 12,
        float: "right"
    },
    buttonContainer: {
        width: '100%',
        position: 'absolute',
        bottom: 12
    },
    dataContainer: {
        padding: 24
    },
}))

const PageButtonPropertiesStyle = makeStyles(theme => ({
    pageContainer: {
        backgroundColor: '#303030',
        height: '100%'
    },
    btnPrev: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        left: 12,
        float: "left"
    },
    btnNext: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        right: 12,
        float: "right"
    },
    buttonContainer: {
        width: '100%',
        position: 'absolute',
        bottom: 12
    },
    title: {
        color: 'white'
    },
    text: {
        color: 'white'
    },
}))

const CustomInputField = createMuiTheme({
    overrides: {
        MuiInputBase: {
            formControl: {
                color: 'white',
            },
        },
        MuiFormLabel: {
            root: {
                color: 'white',
                "&$focused": {
                    color: '#a800ff'
                }
            },
        }
    }
})

export {
    ConfigurationBarStyles,
    HardwareDrawerStyles,
    WelcomeScreenStylesOne,
    WelcomeScreenStylesTwo,
    PageButtonPropertiesStyle,
    CustomInputField
}