import React, { useEffect } from 'react'
import HardwareDrawer from '../components/hardwaredrawer'
import axios from 'axios'
import ConfigurationBar from '../components/configurationbar'
import MissingBackend from './nobackend'

export default function Home(props) {

    const [hardwareComponents, setHardwareComponents] = React.useState({ success: false, data: {} })

    useEffect(() => {
        async function fetchData() {
            const result = await axios('http://localhost:8080/hardware/')
            if (result)
                setHardwareComponents({ data: result.data, success: true })
            else
                setHardwareComponents({ ...hardwareComponents, success: false })
        }
        fetchData()
    }, [])

    return (
        !hardwareComponents.success ? <MissingBackend /> :
            <>
                <ConfigurationBar />
                <HardwareDrawer data={hardwareComponents} />
            </>
    )
}