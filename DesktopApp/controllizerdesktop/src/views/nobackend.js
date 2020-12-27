import React from 'react';
import { Button, Grid, Typography, makeStyles } from '@material-ui/core';
import { useTranslation } from 'react-i18next';

const useStyle = makeStyles(() => ({
    container: {
        padding: 16
    }
}));

/**
 * This View is used to display a message when the backend is not reachable.
 */
// eslint-disable-next-line no-unused-vars
export default function MissingBackend(props) {
    const classes = useStyle();
    const { t } = useTranslation();

    return (
        <Grid container direction="column" alignItems="center" justify="center">
            <Grid item>
                <Grid container direction="column" alignItems="center" justify="center" className={classes.container}>
                    <Typography>{t('MB_NO_RUNNING_DAEMON_1')}</Typography>
                    <Typography>{t('MB_NO_RUNNING_DAEMON_2')}</Typography>
                </Grid>
            </Grid>
            <Grid item>
                <Grid container direction="column" alignItems="center" justify="center" className={classes.container}>
                    <Grid item>
                        <Typography>{t('MB_DOWNLOAD')}</Typography>
                    </Grid>
                    <Grid item>
                        <Button
                            variant="outlined"
                            onClick={() =>
                                window.shell.openExternal(
                                    'https://github.com/GhostyJade/ControllizerDeck'
                                )
                            }
                        >{t('MB_DOWNLOAD_BUTTON')}
                        </Button>
                    </Grid>
                </Grid>
            </Grid>
        </Grid>
    );
}
