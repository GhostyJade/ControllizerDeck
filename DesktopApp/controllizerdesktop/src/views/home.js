import React, { useEffect } from 'react';
import HardwareDrawer from '../components/hardwaredrawer';
import axios from 'axios';
import ConfigurationBar from '../components/configurationbar';
import { server_address, server_port } from '../utils/net';

// eslint-disable-next-line no-unused-vars
export default function Home(props) {

    const [hardwareComponents, setHardwareComponents] = React.useState({ success: false, data: {} });

    useEffect(() => {
        async function fetchData() {
            const result = await axios(`http://${server_address}:${server_port}/hardware/`);
            if (result)
                setHardwareComponents({ data: result.data, success: true });
            else
                setHardwareComponents({ ...hardwareComponents, success: false });
        }
        fetchData();
    }, []);

    return (
        !hardwareComponents.success ? <></> :
            <>
                <ConfigurationBar />
                <HardwareDrawer data={hardwareComponents.data} />
            </>
    );
}