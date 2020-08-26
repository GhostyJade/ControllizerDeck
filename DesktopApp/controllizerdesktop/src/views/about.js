import React from 'react'
import { Typography, makeStyles } from '@material-ui/core'

const AboutStyles = makeStyles(theme => ({
    container: {
        backgroundColor: '#303030',
        height: '100%',
        marginTop: -48
    },
    text: {
        color: 'white'
    },
    textContainer: {
        textAlign: 'center',
        paddingTop: 88 //48px is appbar height
    }
}))

export default function About(props) {
    const styles = AboutStyles()

    return (
        <div className={styles.container}>
            <div className={styles.textContainer}>
                <Typography className={styles.text}>
                    Controllizer Deck - © GhostyJade 2019-2020
                </Typography>
                <Typography className={styles.text}>
                    This application is released under GPLv3.
                </Typography>
            </div>
        </div>
    )
}