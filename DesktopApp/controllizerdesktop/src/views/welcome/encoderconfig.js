import React from 'react'
import { IconButton } from '@material-ui/core'
import { ArrowLeft, Check } from '@material-ui/icons'
import { PageEncodersPropertiesStyle } from '../../utils/styles'

function PageRotaryEncoders(props) {

    const styles = PageEncodersPropertiesStyle()

    const sendData = () => {
        fetch('http://localhost:8080/welcome/',
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
                <IconButton className={styles.btnPrev} onClick={() => props.update({ ...props.state, page: 3 })}>
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