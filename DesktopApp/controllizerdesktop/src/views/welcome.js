import React from 'react'
import PageOne from './welcome/pageone'
import PageTwo from './welcome/pagetwo'
import PageButtonProperties from './welcome/buttonconfig'
import PageRotaryEncoders from './welcome/encoderconfig'

export default function Welcome(props) {
    const [state, setState] = React.useState({ page: 0, btnCount: 0, encodersCount: 0, knobsCount: 0, buttons: { matrix: false, w: 0, h: 0 } })

    if (state.page === 0)
        return <PageOne state={state} update={setState} />
    else if (state.page === 1)
        return <PageTwo state={state} update={setState} />
    else if (state.page === 2)
        return <PageButtonProperties state={state} update={setState} />
    else if (state.page === 4)
        return <PageRotaryEncoders state={state} update={setState} end={props.end} />
    return (
        <div style={{color: 'white'}}>
            Error. Configuration page '{state.page}' is not valid.
        </div>
    )
}

//TODO set com port