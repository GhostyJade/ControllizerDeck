import React, { useEffect } from 'react'

import { Button, MenuItem, Select, FormControl, InputLabel } from '@material-ui/core'
import { server_address, server_port } from '../utils/net'

export default function Settings(props) {

    const [availablePorts, setAvailablePorts] = React.useState([])
    const [port, setPort] = React.useState('');

    const handleSetPort = () => {
        fetch(`http://${server_address}:${server_port}/ports/`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                port
            })
        }).then(response => response.json()).then(e => console.log(e))
    }

    const handlePortChange = (e) => {
        setPort(e.target.value)
    }

    const handleGetPorts = () => {
        fetch(`http://${server_address}:${server_port}/ports/list/`).then(response => response.json())
            .then(data => {
                if (data.result) {
                    setAvailablePorts(data.ports)
                }
            })
    }

    useEffect(handleGetPorts, [])

    return (
        <div>
            <FormControl>
                <InputLabel id="lbl-port">Port</InputLabel>
                <Select labelId="lbl-port" value={port} onChange={handlePortChange}>
                    {availablePorts.map((element, index) => {
                        return <MenuItem key={index} value={element}>{element}</MenuItem>
                    })}</Select>
            </FormControl>
            <Button onClick={handleSetPort}>Set port</Button>
        </div>
    )
}