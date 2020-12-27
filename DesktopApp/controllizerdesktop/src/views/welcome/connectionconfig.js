import React from 'react';
import { PageConnectivityConfigStyles } from '../../utils/styles';
import { Grid, IconButton, Typography } from '@material-ui/core';
import { ArrowLeft, ArrowRight } from '@material-ui/icons';
import Image from 'material-ui-image';

import wifiIcon from '../../resources/wifi.png';
import usbIcon from '../../resources/usb.png';
import clsx from 'clsx';
import PropTypes from 'prop-types';
import { useTranslation } from 'react-i18next';

function PageConnectionConfig(props) {
    const styles = PageConnectivityConfigStyles();
    const { t } = useTranslation();

    return (
        <Grid container direction="column" className={styles.pageContainer}>
            <Grid item className={styles.helperText}>
                <Typography className={styles.title}>{t('CONNECTION_CFG_TITLE')}</Typography>
                <Typography className={styles.text}>{t('CONNECTION_CFG_TEXT')}</Typography>
            </Grid>
            <Grid item className={styles.iconContainer}>
                <Grid container direction="row" justify="space-around">
                    <Grid item className={clsx(styles.icon, props.connectionMethod === 'wifi' && styles.scaledIcon)}>
                        <Image onClick={() => props.setConnectionMethod('wifi')} src={wifiIcon} animationDuration={2000} color="#303030" />
                    </Grid>
                    <Grid item className={clsx(styles.icon, props.connectionMethod === 'usb' && styles.scaledIcon)}>
                        <Image onClick={() => props.setConnectionMethod('usb')} src={usbIcon} animationDuration={4000} color="#303030" />
                    </Grid>
                </Grid>
            </Grid>
            <Grid className={styles.buttonContainer}>
                <IconButton className={styles.btnPrev} onClick={() => props.update({ ...props.state, page: 1 })}>
                    <ArrowLeft />
                </IconButton>
                <IconButton disabled={props.connectionMethod === null} className={styles.btnNext} onClick={() => {
                    props.update({ ...props.state, page: 3 });
                }}>
                    <ArrowRight />
                </IconButton>
            </Grid>
        </Grid>
    );
}

export default PageConnectionConfig;

PageConnectionConfig.propTypes = {
    connectionMethod: PropTypes.object,
    setConnectionMethod: PropTypes.func,
    update: PropTypes.func,
    state: PropTypes.object
};
