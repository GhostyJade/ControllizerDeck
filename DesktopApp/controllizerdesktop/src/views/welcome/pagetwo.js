import React from 'react';
import { WelcomeScreenStylesTwo, CustomInputField } from '../../utils/styles';
import { Typography, FormControl, ThemeProvider, TextField, IconButton } from '@material-ui/core';
import { ArrowLeft, ArrowRight } from '@material-ui/icons';
import { useTranslation } from 'react-i18next';
import PropTypes from 'prop-types';

/* Hardware basic settings */
const PageTwo = (props) => {
    const styles = WelcomeScreenStylesTwo();
    const { t } = useTranslation();

    return (
        <ThemeProvider theme={CustomInputField}>
            <div className={styles.pageTwoContainer}>
                <div className={styles.container}>
                    <Typography className={styles.titleText}>{t('PAGE_TWO_TITLE')}</Typography>
                    <div>
                        <div className={styles.dataContainer}>
                            <FormControl>
                                <TextField
                                    id="buttonsCount"
                                    type="number"
                                    value={props.state.btnCount}
                                    onChange={e => props.update({ ...props.state, btnCount: e.target.value })}
                                    label={t('PAGE_TWO_BTNS')}
                                />
                            </FormControl>
                        </div>
                        <div className={styles.dataContainer}>
                            <FormControl>
                                <TextField
                                    id="encodersCount"
                                    type="number"
                                    value={props.state.encodersCount}
                                    onChange={e => props.update({ ...props.state, encodersCount: e.target.value })}
                                    label={t('PAGE_TWO_ENCS')}
                                />
                            </FormControl>
                        </div>
                        <div className={styles.dataContainer}>
                            <FormControl>
                                <TextField
                                    id="knobsCount"
                                    type="number"
                                    value={props.state.knobsCount}
                                    onChange={e => props.update({ ...props.state, knobsCount: e.target.value })}
                                    label={t('PAGE_TWO_KNBS')}
                                />
                            </FormControl>
                        </div>
                    </div>
                </div>
                <div className={styles.buttonContainer}>
                    <IconButton className={styles.btnPrev} onClick={() => props.update({ ...props.state, page: 0 })}>
                        <ArrowLeft />
                    </IconButton>
                    <IconButton className={styles.btnNext} onClick={() => {
                        props.update({ ...props.state, page: 2 });
                    }}>
                        <ArrowRight />
                    </IconButton>
                </div>
            </div>
        </ThemeProvider>
    );
};

export default PageTwo;

PageTwo.propTypes = {
    update: PropTypes.func,
    state: PropTypes.object
};
