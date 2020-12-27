import React, { useEffect } from 'react';

import {
    Button,
    MenuItem,
    Select,
    FormControl,
    InputLabel,
    Checkbox,
    FormControlLabel,
} from '@material-ui/core';
import { server_address, server_port } from '../utils/net';
import { useTranslation } from 'react-i18next';

// eslint-disable-next-line no-unused-vars
export default function Settings(props) {
    const { t } = useTranslation();
    const [availablePorts, setAvailablePorts] = React.useState([]);
    const [port, setPort] = React.useState('');
    const [viewSettings, setViewSettings] = React.useState({ wifi: false });

    const handleUpdateSettings = () => {
        fetch(`http://${server_address}:${server_port}/settings/`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                port,
                wifi: viewSettings.wifi,
            }),
        })
            .then((response) => response.json())
            .then((e) => console.log(e));
    };

    const handlePortChange = (e) => {
        setPort(e.target.value);
    };

    const handleGetPorts = () => {
        fetch(`http://${server_address}:${server_port}/settings/`)
            .then((response) => response.json())
            .then((data) => {
                if (data.result) {
                    setAvailablePorts(data.ports);
                    setViewSettings({ wifi: data.wifi });
                }
            });
    };

    useEffect(handleGetPorts, []);

    return (
        <div>
            {/* Section USB Port */}
            <div>
                <FormControl disabled={viewSettings.wifi}>
                    <InputLabel id="lbl-port">{t('SETTINGS_PORT')}</InputLabel>
                    <Select labelId="lbl-port" value={port} onChange={handlePortChange}>
                        {availablePorts.map((element, index) => {
                            return (
                                <MenuItem key={index} value={element}>
                                    {element}
                                </MenuItem>
                            );
                        })}
                    </Select>
                </FormControl>
            </div>
            {/* Section Wifi */}
            <div>
                <FormControlLabel
                    control={
                        <Checkbox
                            checked={viewSettings.wifi}
                            onChange={(e) =>
                                setViewSettings({ ...viewSettings, wifi: e.target.checked })
                            }
                        />
                    }
                    label={t('SETTINGS_USE_WIFI')}
                />
            </div>
            <Button onClick={handleUpdateSettings}>{t('SETTINGS_UPDATE')}</Button>
        </div>
    );
}
