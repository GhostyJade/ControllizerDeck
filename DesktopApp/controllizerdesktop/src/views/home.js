import React, { useEffect } from 'react'
import HardwareDrawer from '../components/hardwaredrawer'
import axios from 'axios'
import ConfigurationBar from '../components/configurationbar'

export default function Home(props) {

    const [hardwareComponents, setHardwareComponents] = React.useState({})


    useEffect(() => {
        async function fetchData() {
            const result = await axios('http://localhost:8080/hardware/')
            setHardwareComponents(result.data)
        }
        fetchData()
    }, [])

    return (
        <>
            <ConfigurationBar />
            <HardwareDrawer data={hardwareComponents} />
        </>
    )
}