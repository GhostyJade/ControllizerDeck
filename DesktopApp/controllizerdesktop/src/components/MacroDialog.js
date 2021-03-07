import React from 'react';
import PropTypes from 'prop-types';
import {
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
    IconButton,
    Toolbar,
    Typography,
} from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import DeleteIcon from '@material-ui/icons/Delete';
import RecordIcon from '@material-ui/icons/FiberManualRecord';
import RecordOffIcon from '@material-ui/icons/HighlightOff';

import Hotkeys from 'react-hot-keys';

import Keyboard from '@uiw/react-mac-keyboard';

export default function MacroDialog(props) {
    const [record, setRecording] = React.useState(false);

    const registerMacro = () => {
        setRecording(!record);
    };

    const clearMacro = () => {
        props.setKeyCode([]);
    };

    // eslint-disable-next-line no-unused-vars
    const registerStroke = (keyName, e, handle) => {
        if (!record) return;
        const oldKeys = props.keyCode;
        oldKeys.push(e.keyCode);
        props.setKeyCode(oldKeys);
    };

    return (
        <Dialog open={props.isOpen} maxWidth="lg">
            <DialogTitle>
                <Toolbar disableGutters>
                    <IconButton style={{ padding: 0, paddingRight: 4 }} onClick={props.close}>
                        <CloseIcon />
                    </IconButton>
                    <Typography>
                        Create a Keystroke
                    </Typography>
                    <IconButton onClick={registerMacro}>
                        {
                            !record ?
                                <RecordIcon /> : <RecordOffIcon />
                        }
                    </IconButton>
                    <IconButton onClick={clearMacro}>
                        <DeleteIcon />
                    </IconButton>
                </Toolbar>
            </DialogTitle>
            <DialogContent>
                <Hotkeys
                    keyName="*"
                    onKeyUp={registerStroke}
                >
                    <Keyboard keyCode={props.keyCode} />
                </Hotkeys>
            </DialogContent>
            <DialogActions></DialogActions>
        </Dialog>
    );
}

MacroDialog.propTypes = {
    isOpen: PropTypes.bool,
    close: PropTypes.func,
    keyCode: PropTypes.array,
    setKeyCode: PropTypes.func
};
