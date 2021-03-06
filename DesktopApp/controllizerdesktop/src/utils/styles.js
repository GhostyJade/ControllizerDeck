import { makeStyles, createMuiTheme } from '@material-ui/core';

const drawerWidth = 230;

// eslint-disable-next-line no-unused-vars
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
}));

const HardwareDrawerStyles = {
    container: {
        marginTop: 34,
        marginLeft: 34,
    }
};

// eslint-disable-next-line no-unused-vars
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
        float: 'right'
    },
    btnNextContainer: {
        width: '100%',
        position: 'absolute',
        bottom: 12
    }
}));

// eslint-disable-next-line no-unused-vars
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
        float: 'left'
    },
    btnNext: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        right: 12,
        float: 'right'
    },
    buttonContainer: {
        width: '100%',
        position: 'absolute',
        bottom: 12
    },
    dataContainer: {
        padding: 24
    },
}));

// eslint-disable-next-line no-unused-vars
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
        float: 'left'
    },
    btnNext: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        right: 12,
        float: 'right'
    },
    buttonContainer: {
        width: '100%',
        position: 'absolute',
        bottom: 12
    },
    textContainer: {
        textAlign: 'center',
        paddingBottom: 22
    },
    title: {
        paddingTop: 18,
        fontSize: 20,
        color: 'white'
    },
    text: {
        color: '#acacac'
    },
    inputText: {
        color: 'white',
        padding: 10,
        paddingTop: 20
    },
    inputContainer: {
        display: 'flex',
        justifyContent: 'center'
    },
    checkboxContainer: {
        color: 'white'
    },
    checkbox: {
        color: 'white'
    }
}));

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
                '&$focused': {
                    color: '#a800ff'
                }
            },
        }
    }
});

// eslint-disable-next-line no-unused-vars
const PageEncodersPropertiesStyle = makeStyles(theme => ({
    pageContainer: {
        backgroundColor: '#303030',
        height: '100%'
    },
    btnPrev: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        left: 12,
        float: 'left'
    },
    btnNext: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        right: 12,
        float: 'right'
    },
    buttonContainer: {
        width: '100%',
        position: 'absolute',
        bottom: 12
    },
}));

// eslint-disable-next-line no-unused-vars
const PageSerialConfigStyles = makeStyles(theme => ({
    pageContainer: {
        backgroundColor: '#303030',
        height: '100%'
    },
    btnPrev: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        left: 12,
        float: 'left'
    },
    btnNext: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        right: 12,
        float: 'right'
    },
    buttonContainer: {
        width: '100%',
        position: 'absolute',
        bottom: 12
    },
    helperText: {
        textAlign: 'center'
    },
    title: {
        color: 'white',
        fontSize: 20
    },
    text: {
        color: '#acacac',
        fontSize: 16
    },
    inputPortBarContainer: {
        minWidth: 150
    },
}));

// eslint-disable-next-line no-unused-vars
const PageConnectivityConfigStyles = makeStyles(theme => ({
    pageContainer: {
        backgroundColor: '#303030',
        height: '100%'
    },
    btnPrev: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        left: 12,
        float: 'left'
    },
    btnNext: {
        color: 'white',
        borderRadius: '50%',
        backgroundColor: '#696b6e',
        right: 12,
        float: 'right'
    },
    buttonContainer: {
        width: '100%',
        position: 'absolute',
        bottom: 12
    },
    helperText: {
        textAlign: 'center'
    },
    title: {
        color: 'white',
        fontSize: 20
    },
    text: {
        color: '#acacac',
        fontSize: 16
    },
    iconContainer: {
        paddingTop: 40
    },
    icon: {
        width: 256,
        height: 256
    },
    scaledIcon: {
        transform: 'scale(1.2)'
    }
}));

export {
    ConfigurationBarStyles,
    HardwareDrawerStyles,
    WelcomeScreenStylesOne,
    WelcomeScreenStylesTwo,
    PageButtonPropertiesStyle,
    CustomInputField,
    PageEncodersPropertiesStyle,
    PageSerialConfigStyles,
    PageConnectivityConfigStyles,
};