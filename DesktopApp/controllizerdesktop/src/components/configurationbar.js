import React, { useEffect } from 'react';
import { Drawer, Toolbar, Button, Select, FormControl, InputLabel, MenuItem, InputAdornment, IconButton, Input, TextField } from '@material-ui/core';
import { useTracked } from './DataContainer';

import { Add as AddIcon } from '@material-ui/icons';

import { ConfigurationBarStyles } from '../utils/styles';
import { server_address, server_port } from '../utils/net';

import PropTypes from 'prop-types';
import { useTranslation } from 'react-i18next';
import MacroDialog from './MacroDialog';

const ParametersComponent = ({ itemData, setItemData, state }) => {
    const id = itemData.action;
    if (id === 1)
        return <FileChooser state={state} itemData={itemData} setItemData={setItemData} />;
    if (id === 2)
        return <WebsitePicker state={state} itemData={itemData} setItemData={setItemData} />;
    if (id === 3)
        return <Macro state={state} itemData={itemData} setItemData={setItemData} />;
    return null;
};

ParametersComponent.propTypes = {
    itemData: PropTypes.object,
    setItemData: PropTypes.func,
    state: PropTypes.object
};

const Macro = (props) => {
    const styles = ConfigurationBarStyles();
    const { t } = useTranslation();
    const [macroDialogOpen, setMacroDialogOpen] = React.useState(false);
    const [keyCode, setKeyCode] = React.useState(props.itemData.keyCodes || []);

    const setKeyCodes = (item) => {
        setKeyCode(item);
        props.setItemData({ ...props.itemData, keyCodes: keyCode });
    };

    const openMacroDialog = () => {
        setMacroDialogOpen(true);
    };

    const closeMacroDialog = () => {
        setMacroDialogOpen(false);
    };

    return (
        <div>
            <FormControl>
                <TextField
                    id="macroName"
                    type="text"
                    className={styles.actionTypeBox}
                    value={props.itemData.name}
                    onChange={e => props.setItemData({ ...props.itemData, name: e.target.value })}
                    label={t('MACRO_NAME')}
                />
            </FormControl>
            <FormControl className={styles.actionTypeBox} >
                <InputLabel id="macroType">{t('MACRO_TYPE')}</InputLabel>
                <Select labelId="macroType" value={props.itemData.macroType} onChange={e => props.setItemData({ ...props.itemData, macroType: e.target.value })}>
                    <MenuItem value={0}>Keystroke</MenuItem>
                    <MenuItem value={1}>Text</MenuItem>
                    <MenuItem value={2} disabled>Mouse</MenuItem>
                </Select>
            </FormControl>
            {
                props.itemData.macroType === 0 && (
                    <FormControl>
                        <TextField
                            id="macroData"
                            type="text"
                            className={styles.actionTypeBox}
                            value={props.itemData.keyCodes}
                            label={t('MACRO_PICKER')}
                            InputProps={{
                                endAdornment: <InputAdornment position="end"><IconButton onClick={openMacroDialog}><AddIcon /></IconButton></InputAdornment>
                            }}
                        />
                    </FormControl>
                )}
            <MacroDialog isOpen={macroDialogOpen} close={closeMacroDialog} keyCode={keyCode} setKeyCode={setKeyCodes} />
        </div>
    );
};

Macro.propTypes = {
    itemData: PropTypes.object,
    setItemData: PropTypes.func
};

const WebsitePicker = (props) => {
    const styles = ConfigurationBarStyles();
    const { t } = useTranslation();
    return (
        <div>
            <FormControl>
                <TextField
                    id="websiteName"
                    type="text"
                    className={styles.actionTypeBox}
                    value={props.itemData.name}
                    onChange={e => props.setItemData({ ...props.itemData, name: e.target.value })}
                    label={t('WEBSITE_PICKER_NAME')}
                />
            </FormControl>
            <FormControl>
                <TextField
                    id="websiteUri"
                    type="text"
                    className={styles.actionTypeBox}
                    value={props.itemData.websiteUri}
                    onChange={e => props.setItemData({ ...props.itemData, websiteUri: e.target.value })}
                    label={t('WEBSITE_PICKER_URL')}
                />
            </FormControl>
        </div>
    );
};

WebsitePicker.propTypes = {
    itemData: PropTypes.object,
    setItemData: PropTypes.func
};

const DataComponent = (props) => {
    const styles = ConfigurationBarStyles();
    const { t } = useTranslation();
    const { state, itemData, setItemData } = props;

    if (!state.selectedItem) {
        return null;
    }

    return (
        <div>
            <FormControl className={styles.actionTypeBox}>
                <InputLabel id="actionType">{t('ACTION_TYPE')}</InputLabel>
                <Select value={itemData.action} onChange={(e) => setItemData({ ...itemData, action: e.target.value })} labelId="actionType">
                    <MenuItem value={0}>{t('ACTION_TYPE_NONE')}</MenuItem>
                    <MenuItem value={1}>{t('ACTION_TYPE_RUN')}</MenuItem>
                    <MenuItem value={2}>{t('ACTION_TYPE_OPEN_WEBSITE')}</MenuItem>
                    <MenuItem value={3}>{t('ACTION_TYPE_MACRO')}</MenuItem>
                </Select>
            </FormControl>
            <ParametersComponent state={state} itemData={itemData} setItemData={setItemData} />
        </div>
    );
};

DataComponent.propTypes = {
    itemData: PropTypes.object,
    state: PropTypes.object,
    setItemData: PropTypes.func
};

const FileChooser = (props) => {
    const styles = ConfigurationBarStyles();
    const { t } = useTranslation();

    const ShowFilePicker = () => {
        const dialogResult = window.dialog.showOpenDialogSync({ properties: ['openFile'] });
        if (dialogResult) //It's length is 1 if the user has selected an app. It contains the app path at index 0
            props.setItemData({ ...props.itemData, path: dialogResult[0] });
    };

    return (
        <div>
            <FormControl>
                <TextField
                    id="actionName"
                    type="text"
                    className={styles.actionTypeBox}
                    value={props.itemData.name}
                    onChange={e => props.setItemData({ ...props.itemData, name: e.target.value })}
                    label={t('FILE_CHOOSER_ACTION_NAME')}
                />
            </FormControl>
            <FormControl className={styles.executableBox}>
                <InputLabel htmlFor="file">{t('FILE_CHOOSER_EXECUTABLE_PATH')}</InputLabel>
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
    );
};

FileChooser.propTypes = {
    itemData: PropTypes.object,
    state: PropTypes.object,
    setItemData: PropTypes.func
};


// eslint-disable-next-line no-unused-vars
export default function ConfigurationBar(props) {
    const { t } = useTranslation();

    const [state,] = useTracked();
    const styles = ConfigurationBarStyles();

    const [itemData, setItemData] = React.useState({ action: 0, name: '', path: '', websiteUri: '', keyCodes: [], macroType: 0 });

    useEffect(() => {
        if (state.selectedItem != null)
            if (state.selectedItem.AssociatedAction !== null) {
                if (state.selectedItem.AssociatedAction.Type === 1) { //action 1 = launch program           
                    setItemData({ action: state.selectedItem.AssociatedAction.Type, name: state.selectedItem.AssociatedAction.AppName, path: state.selectedItem.AssociatedAction.FullAppDirectory });
                } else if (state.selectedItem.AssociatedAction.Type === 2) { //action 2 = open website
                    setItemData({ action: state.selectedItem.AssociatedAction.Type, name: state.selectedItem.AssociatedAction.WebsiteName, websiteUri: state.selectedItem.AssociatedAction.WebsiteUri });
                } else if (state.selectedItem.AssociatedAction.Type === 3) {// action 3 = macro
                    setItemData({ action: state.selectedItem.AssociatedAction.Type, name: state.selectedItem.AssociatedAction.WebsiteName, keyCodes: state.selectedItem.AssociatedAction.WebsiteUri });
                }
            } else {
                setItemData({ action: 0, name: '', path: '', websiteUri: '', keyCodes: [], macroType: 0 });
            }

    }, [state.selectedItem]);

    const sendData = () => {
        //if (itemData.action === 0 || itemData.name === '' || itemData.path === '') return;// TODO check path if action number is 1, allow 0 to be action reset
        //TODO add checks
        fetch(`http://${server_address}:${server_port}/hardware/functions/`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ id: state.selectedItem.Identifier, data: itemData })
        }).then(response => response.json()).then(e => console.log(e));
    };

    return (
        <Drawer classes={{ paper: styles.drawerPaper }} className={styles.drawer} variant="permanent" anchor="right">
            <Toolbar />
            <DataComponent state={state} itemData={itemData} setItemData={setItemData} />
            <Button className={styles.saveButton} size="small" variant="contained" onClick={sendData}>{t('BTN_SAVE')}</Button>
        </Drawer>
    );
}

