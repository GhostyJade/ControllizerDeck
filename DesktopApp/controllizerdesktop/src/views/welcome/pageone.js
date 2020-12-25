import React from 'react';
import { WelcomeScreenStylesOne } from '../../utils/styles'

import Logo from '../../resources/logo192.png'
import { Typography, IconButton } from '@material-ui/core'
import { ArrowRight } from '@material-ui/icons'

/**Welcome screen */
const PageOne = (props) => {
    const styles = WelcomeScreenStylesOne()
    return (
        <div className={styles.pageOneContainer}>
            <div className={styles.infoContainer}>
                <img src={Logo} alt="logo"></img>
                <Typography className={styles.pageOneTitleText}>Welcome to Controllizer Deck</Typography>
                <Typography className={styles.pageOneText}>This wizard will help you configure the hardware description used by this application</Typography>
            </div>
            <div className={styles.btnNextContainer}>
                <IconButton className={styles.btnNext} onClick={() => props.update({ ...props.state, page: 1 })}>
                    <ArrowRight />
                </IconButton>
            </div>
        </div>
    )
}

export default PageOne;