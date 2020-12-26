import React, { useEffect } from 'react'
import { PageSerialConfigStyles } from '../../utils/styles'
import { IconButton, FormControl, InputLabel, NativeSelect, Typography, createMuiTheme, ThemeProvider, TextField } from '@material-ui/core'
import { ArrowLeft, ArrowRight } from '@material-ui/icons'

import { server_address, server_port } from '../../utils/net'

const CustomSelectField = createMuiTheme({
    overrides: {
        MuiNativeSelect: {
            icon: { color: 'white' },
            select: {
                color: 'white',
                '& option': {
                    color: 'white'
                },
            },
        },
    }
})

function SerialConfig(props) {
    const styles = PageSerialConfigStyles()

    const [availablePorts, setAvailablePorts] = React.useState([])

    const handleGetPorts = () => {
        fetch(`http://${server_address}:${server_port}/settings/`).then(response => response.json())
            .then(data => {
                if (data.result) {
                    setAvailablePorts(data.ports)
                }
            })
    }

    useEffect(handleGetPorts, [])

    const handlePortChange = (e) => {
        props.update({ ...props.state, serialPort: e.target.value })
    }

    return (
        <ThemeProvider theme={CustomSelectField}>
            <div className={styles.pageContainer}>
                <div className={styles.helperText}>
                    <Typography className={styles.title}>Serial port settings</Typography>
                    <Typography className={styles.text}>Here's you can set the serial port used by this application. This port is used to listen to the hardware device triggers. </Typography>
                </div>
                <div>
                    <FormControl className={styles.inputPortBarContainer}>
                        <InputLabel htmlFor="lbl-port">Port</InputLabel>
                        <NativeSelect id="lbl-port" value={props.state.serialPort} onChange={handlePortChange}>
                            <option style={{ backgroundColor: '#333333' }} value="" disabled>Port</option>
                            {availablePorts.map((element, index) => {
                                return <option style={{ backgroundColor: '#333333' }} key={index} value={element}>{element}</option>
                            })}
                        </NativeSelect>
                    </FormControl>
                </div>
                <div className={styles.buttonContainer}>
                    <IconButton className={styles.btnPrev} onClick={() => props.update({ ...props.state, page: 2 })}>
                        <ArrowLeft />
                    </IconButton>
                    <IconButton className={styles.btnNext} onClick={() => {
                        props.update({ ...props.state, page: 4 })
                    }}>
                        <ArrowRight />
                    </IconButton>
                </div>
            </div>
        </ThemeProvider>
    )
}

function WifiConfig(props) {
    const styles = PageSerialConfigStyles()

    const handlePortChange = (e) => {
        props.update({ ...props.state, wifiPort: e.target.value })
    }

    return (
        <ThemeProvider theme={CustomSelectField}>
            <div className={styles.pageContainer}>
                <div className={styles.helperText}>
                    <Typography className={styles.title}>Wi-Fi settings</Typography>
                    <Typography className={styles.text}>Here's you can set the socket port used by this application. This port is used to listen to the hardware device triggers. </Typography>
                </div>
                <div>
                    <FormControl className={styles.inputPortBarContainer}>
                        <TextField label="Port" value={props.state.wifiPort} onChange={handlePortChange} type="number" />
                    </FormControl>
                </div>
                <div className={styles.buttonContainer}>
                    <IconButton className={styles.btnPrev} onClick={() => props.update({ ...props.state, page: 2 })}>
                        <ArrowLeft />
                    </IconButton>
                    <IconButton className={styles.btnNext} onClick={() => {
                        props.update({ ...props.state, page: 4 })
                    }}>
                        <ArrowRight />
                    </IconButton>
                </div>
            </div>
        </ThemeProvider>
    )
}

function PageConnectivityConfig(props) {
    if (props.connectionMethod === 'usb')
        return <SerialConfig {...props} />
    return <WifiConfig {...props} />
}

export default PageConnectivityConfig