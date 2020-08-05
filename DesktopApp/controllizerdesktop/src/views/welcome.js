import React from 'react'
import { Typography, IconButton, FormControl, TextField, ThemeProvider, createMuiTheme } from '@material-ui/core'
import { WelcomeScreenStylesOne, WelcomeScreenStylesTwo } from '../utils/styles'
import { ArrowRight, ArrowLeft } from '@material-ui/icons'

import Logo from '../resources/logo192.png'

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
                <IconButton className={styles.btnNext} onClick={() => props.update({ id: 1 })}>
                    <ArrowRight />
                </IconButton>
            </div>
        </div>
    )
}

const theme = createMuiTheme({
    overrides: {
        MuiInputBase: {
            formControl: {
                color: 'white',
            },
        },
        MuiFormLabel: {
            root: {
                color: 'white',
                "&$focused": {
                    color: '#a800ff'
                }
            },
        }
    }
})

/**Hardware basic settings */
const PageTwo = (props) => {
    const [state, setState] = React.useState({ btnCount: 0, encodersCount: 0, knobsCount: 0 })

    const styles = WelcomeScreenStylesTwo()

    return (
        <ThemeProvider theme={theme}>
            <div className={styles.pageTwoContainer}>
                <div className={styles.container}>
                    <Typography className={styles.titleText}>Hardware Configuration</Typography>
                    <div>
                        <div className={styles.dataContainer}>
                            <FormControl>
                                <TextField
                                    id="buttonsCount"
                                    type="number"
                                    value={state.btnCount}
                                    onChange={e => setState({ ...state, btnCount: e.target.value })}
                                    label="Button count"
                                />
                            </FormControl>
                        </div>
                        <div className={styles.dataContainer}>
                            <FormControl>
                                <TextField
                                    id="encodersCount"
                                    type="number"
                                    value={state.encodersCount}
                                    onChange={e => setState({ ...state, encodersCount: e.target.value })}
                                    label="Encoder count"
                                />
                            </FormControl>
                        </div>
                        <div className={styles.dataContainer}>
                            <FormControl>
                                <TextField
                                    id="knobsCount"
                                    type="number"
                                    value={state.knobsCount}
                                    onChange={e => setState({ ...state, knobsCount: e.target.value })}
                                    label="Knob count"
                                />
                            </FormControl>
                        </div>
                    </div>
                </div>
                <div className={styles.buttonContainer}>
                    <IconButton className={styles.btnPrev} onClick={() => props.update({ id: 0 })}>
                        <ArrowLeft />
                    </IconButton>
                    <IconButton className={styles.btnNext} onClick={() => props.update({ id: 2 })}>
                        <ArrowRight />
                    </IconButton>
                </div>
            </div>
        </ThemeProvider>
    )
}

export default function Welcome() {
    const [state, setState] = React.useState({ id: 0 });
    if (state.id === 0)
        return <PageOne update={setState} />
    else if (state.id === 1)
        return <PageTwo update={setState} />
    return (
        <div>
            Error
        </div>
    )

}