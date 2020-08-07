import React from 'react'
import { Typography, IconButton, FormControl, TextField, ThemeProvider, FormControlLabel, Checkbox } from '@material-ui/core'
import { PageButtonPropertiesStyle, CustomInputField } from '../../utils/styles'
import { ArrowRight, ArrowLeft } from '@material-ui/icons'

const PageButtonProperties = (props) => {
    const styles = PageButtonPropertiesStyle()

    return (
        <ThemeProvider theme={CustomInputField}>
            <div className={styles.pageContainer}>
                <div className={styles.container}>
                    <div className={styles.textContainer}>
                        <Typography className={styles.title}>Button settings</Typography>
                        <Typography className={styles.text}>Here's you can configure all the settings relative to the hardware's buttons</Typography>
                    </div>
                    <div>
                        <div className={styles.textContainer}>
                            <FormControlLabel
                                className={styles.checkboxContainer}
                                control={
                                    <Checkbox
                                        checked={props.state.buttons.matrix}
                                        onChange={e => { props.update({ ...props.state, buttons: { ...props.state.buttons, matrix: e.target.checked } }) }}
                                        name="isMatrix"
                                        className={styles.checkbox}
                                    />
                                }
                                label="Is button matrix?"
                            />
                        </div>
                        {
                            props.state.buttons.matrix ?
                                <div className={styles.inputContainer}>
                                    <FormControl>
                                        <TextField
                                            id="matrixW"
                                            type="number"
                                            value={props.state.buttons.w}
                                            onChange={e => { if (e.target.value >= 0) props.update({ ...props.state, buttons: { ...props.state.buttons, w: e.target.value } }) }}
                                            label="Matrix Width"
                                        />
                                    </FormControl>
                                    <Typography className={styles.inputText}>x</Typography>
                                    <FormControl>
                                        <TextField
                                            id="matrixH"
                                            type="number"
                                            value={props.state.buttons.h}
                                            onChange={e => { if (e.target.value >= 0) props.update({ ...props.state, buttons: { ...props.state.buttons, h: e.target.value } }) }}
                                            label="Matrix Height"
                                        />
                                    </FormControl>
                                </div>
                                :
                                null
                        }
                    </div>
                </div>
                <div className={styles.buttonContainer}>
                    <IconButton className={styles.btnPrev} onClick={() => props.update({ ...props.state, page: 1 })}>
                        <ArrowLeft />
                    </IconButton>
                    <IconButton className={styles.btnNext} onClick={() => {
                        props.update({ ...props.state, page: 4 })
                    }}>
                        <ArrowRight />
                    </IconButton>
                </div>
            </div>
        </ThemeProvider>
    )
}

export default PageButtonProperties