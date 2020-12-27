import React from 'react';
import PropTypes from 'prop-types';

import Logo from '../../resources/logo192.png';
import { WelcomeScreenStylesOne } from '../../utils/styles';
import { Typography, IconButton } from '@material-ui/core';
import { ArrowRight } from '@material-ui/icons';
import { useTranslation } from 'react-i18next';


/**Welcome screen */
const PageOne = (props) => {
    const styles = WelcomeScreenStylesOne();
    const { t } = useTranslation();
    return (
        <div className={styles.pageOneContainer}>
            <div className={styles.infoContainer}>
                <img src={Logo} alt="logo"></img>
                <Typography className={styles.pageOneTitleText}>{t('PAGE_ONE_TITLE')}</Typography>
                <Typography className={styles.pageOneText}>{t('PAGE_ONE_TEXT')}</Typography>
            </div>
            <div className={styles.btnNextContainer}>
                <IconButton className={styles.btnNext} onClick={() => props.update({ ...props.state, page: 1 })}>
                    <ArrowRight />
                </IconButton>
            </div>
        </div>
    );
};

export default PageOne;

PageOne.propTypes = {
    update: PropTypes.func,
    state: PropTypes.object
};
