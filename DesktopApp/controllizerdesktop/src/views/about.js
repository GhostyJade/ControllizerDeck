import React from 'react'
import { Typography, makeStyles } from '@material-ui/core'
import { useTranslation } from 'react-i18next';

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
    const { t } = useTranslation();

    return (
        <div className={styles.container}>
            <div className={styles.textContainer}>
                <Typography className={styles.text}>
                    Controllizer Deck - © GhostyJade 2019-2020
                </Typography>
                <Typography className={styles.text}>
                    {t('ABOUT_LICENSING')}
                </Typography>
            </div>
        </div>
    )
}