import React from 'react'
import { IconButton } from '@material-ui/core'
import { ArrowLeft, Check } from '@material-ui/icons'
import { PageEncodersPropertiesStyle } from '../../utils/styles'
import { server_address, server_port } from '../../utils/net'

function PageRotaryEncoders(props) {
    const styles = PageEncodersPropertiesStyle()

    const sendData = () => {
        fetch(`http://${server_address}:${server_port}/welcome/`,
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(props.state)
            })
            .then(response => response.json())
            .then(result => { if (result.result) props.end() })
    }

    return (
        <div className={styles.pageContainer}>
            <div>
                Rotary encoders settings (TODO)
            </div>
            <div className={styles.buttonContainer}>
                <IconButton className={styles.btnPrev} onClick={() => props.update({ ...props.state, page: 4 })}>
                    <ArrowLeft />
                </IconButton>
                <IconButton className={styles.btnNext} onClick={() => {
                    sendData()
                }}>
                    <Check />
                </IconButton>
            </div>
        </div>
    )

}

export default PageRotaryEncoders