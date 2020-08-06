import React from 'react'
import { WelcomeScreenStylesTwo, CustomInputField } from '../../utils/styles'
import { Typography, FormControl, ThemeProvider, TextField, IconButton } from '@material-ui/core'
import { ArrowLeft, ArrowRight } from '@material-ui/icons'

/**Hardware basic settings */
const PageTwo = (props) => {
    const styles = WelcomeScreenStylesTwo()

    const sendData = () => {
        fetch('http://localhost:8080/welcome/', { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(props.state) })
    }

    return (
        <ThemeProvider theme={CustomInputField}>
            <div className={styles.pageTwoContainer}>
                <div className={styles.container}>
                    <Typography className={styles.titleText}>Hardware Configuration</Typography>
                    <div>
                        <div className={styles.dataContainer}>
                            <FormControl>
                                <TextField
                                    id="buttonsCount"
                                    type="number"
                                    value={props.state.btnCount}
                                    onChange={e => props.update({ ...props.state, btnCount: e.target.value })}
                                    label="Button count"
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
                                    label="Encoder count"
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
                                    label="Knob count"
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
                        props.update({ ...props.state, page: 2 })
                    }}>
                        <ArrowRight />
                    </IconButton>
                </div>
            </div>
        </ThemeProvider>
    )
}

export default PageTwo;