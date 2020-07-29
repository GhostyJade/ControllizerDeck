import React from 'react'
import { Container, Typography } from '@material-ui/core'
/**
 * This View is used to display a message when the backend is not reachable.
 */
export default function MissingBackend(props) {
    return (
        <Container>
            <Typography>
                The application daemon is not running. Please launch it and reopen this application.
            </Typography>
        </Container>
    )
}